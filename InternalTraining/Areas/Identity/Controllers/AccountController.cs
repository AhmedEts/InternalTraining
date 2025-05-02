using InternalTraining.Models.ViewModel;
using InternalTraining.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InternalTraining.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._roleManager = roleManager;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (_roleManager.Roles.IsNullOrEmpty())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Company"));
                await _roleManager.CreateAsync(new IdentityRole("Employee"));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = registerVm.UserName,
                    Email = registerVm.Email,
                };

                var result = await userManager.CreateAsync(appUser, registerVm.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(appUser, false);
                    await userManager.AddToRoleAsync(appUser,"Admin");
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }
            return View(registerVm);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (ModelState.IsValid)
            {
                var appUser = await userManager.FindByEmailAsync(loginVm.Email);

                if (appUser != null)
                {
                    var result = await userManager.CheckPasswordAsync(appUser, loginVm.Password);
                    if (result)
                    {
                        await signInManager.SignInAsync(appUser, loginVm.RememberMe);
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Cannot Found The Email");
                        ModelState.AddModelError("Password", "Donot Match The Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Cannot Found The Email");
                    ModelState.AddModelError("Password", "Donot Match The Password");

                }
            }
            return View(loginVm);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account", new { area = "Identity" });
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var appUser = await userManager.GetUserAsync(User);
            if (appUser == null)
            {
                ModelState.AddModelError("", "Sorry Something is Wrong");
            }

            var profileInfo = new ProfileVm
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                Email = appUser.Email
            };
            return View(profileInfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileVm profileVm)
        {
            if (ModelState.IsValid)
            {
                var appUser = await userManager.GetUserAsync(User);
                if (appUser == null)
                {
                    ModelState.AddModelError("", "Sorry Something is wrong");
                    return View(profileVm);
                }

                if (appUser.Email != profileVm.Email)
                {
                    var emailToken = await userManager.GenerateChangeEmailTokenAsync(appUser, profileVm.Email);
                    var result = await userManager.ChangeEmailAsync(appUser, profileVm.Email, emailToken);

                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(profileVm);
                    }

                }

                if (appUser.UserName != profileVm.UserName)
                {
                    appUser.UserName = profileVm.UserName;
                    var result = await userManager.UpdateAsync(appUser);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(profileVm);
                    }

                }

                if (!string.IsNullOrEmpty(profileVm.CurrentPassword) && !string.IsNullOrEmpty(profileVm.NewPassword))
                {
                    var result = await userManager.ChangePasswordAsync(appUser, profileVm.CurrentPassword, profileVm.NewPassword);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(profileVm);
                    }

                }
                await signInManager.RefreshSignInAsync(appUser);
                return RedirectToAction("Index", "Home", new { area = "Company" });
            }
            return View(profileVm);
        }

    }
}

