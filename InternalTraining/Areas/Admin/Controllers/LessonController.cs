using InternalTraining.Models;
using InternalTraining.Repositories;
using InternalTraining.Repositories.IRepository;
using InternalTraining.Unit_of_Work;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternalTraining.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LessonController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LessonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var lessons = _unitOfWork.Lessons.Get(includes: [e => e.Chapter]);
            return View(lessons.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var chapters = _unitOfWork.Chapters.Get();
            ViewBag.ChapterId = new SelectList(chapters, "Id", "Name");
            return View(new Lesson());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Lessons.Create(lesson);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            var chapters = _unitOfWork.Chapters.Get();
            ViewBag.ChapterId = new SelectList(chapters, "Id", "Name", lesson.ChapterId);
            return View(lesson);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var lesson = _unitOfWork.Lessons.GetOne(e => e.Id == id);
            if (lesson == null)
                return RedirectToAction("Error", "Home");

            var chapters = _unitOfWork.Chapters.Get();
            ViewBag.ChapterId = new SelectList(chapters, "Id", "Name", lesson.ChapterId);
            return View(lesson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Lessons.Update(lesson);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            var chapters = _unitOfWork.Chapters.Get();
            ViewBag.ChapterId = new SelectList(chapters, "Id", "Name", lesson.ChapterId);
            return View(lesson);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var lesson = _unitOfWork.Lessons.GetOne(e => e.Id == id);
            if (lesson == null)
                return RedirectToAction("Error", "Home");

            _unitOfWork.Lessons.Delete(lesson);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}
