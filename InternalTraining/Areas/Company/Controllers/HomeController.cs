using Microsoft.AspNetCore.Mvc;

namespace InternalTraining.Areas.Company.Controllers
{
    [Area ("Company")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
