using InternalTraining.Models;
using InternalTraining.Repositories;
using InternalTraining.Repositories.IRepository;
using InternalTraining.Unit_of_Work;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternalTraining.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var courses = _unitOfWork.Courses.Get();
            return View( courses.ToList());
        }


            [HttpGet]
        public IActionResult Create()
        {
            var courses = _unitOfWork.Courses.Get();
            
            ViewData["Courses"] = courses.ToList();

            return View(new Course());
        }

        [HttpPost]
        public IActionResult Create(Course course, IFormFile? file)
        {

            // Validation
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    // Save img in wwwroot
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\admin", fileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(stream);
                    }

                    // Save img name in db
                    course.CourseImage = fileName;
                }

                _unitOfWork.Courses.Create(course);
                _unitOfWork.Courses.Commit();

               // return RedirectToAction("Index");
                return RedirectToAction("Index", "Course", new { area = "admin" });
            }
            return View(course);
        }
    }
}