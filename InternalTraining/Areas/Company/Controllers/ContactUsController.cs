using InternalTraining.Models;
using InternalTraining.Unit_of_Work;
using Microsoft.AspNetCore.Mvc;

namespace InternalTraining.Areas.Company.Controllers
{
    [Area("Company")]
    public class ContactUsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ContactUsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {


            return View();
        }
        // filling the form
        [HttpPost]
        public IActionResult Index(ContactUs contact)
        {
            if (ModelState.IsValid)
            {
                if (contact!= null)
                {
                    unitOfWork.ContactsUs.Create(contact);
                    unitOfWork.Commit();
                }
                return RedirectToAction("Index", "Home", new { area = "Company" });
            }
            else

            {
                return View(contact);
            }
           
        }
    }
}
