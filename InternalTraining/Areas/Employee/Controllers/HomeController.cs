using Microsoft.AspNetCore.Mvc;

namespace InternalTraining.Areas.Employee.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
