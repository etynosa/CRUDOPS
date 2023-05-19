using CRUDOPS.Infastructure.Database.Models;
using CRUDOPS.Infastructure.Database.Repositories;
using CRUDOPS.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOPS.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<CourseController> _logger;
        public CourseController(ICourseRepository courseRepository, ILogger<CourseController> logger)
        {
            _courseRepository = courseRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var courses = _courseRepository.GetAll().ToList();
            _logger.LogInformation($"Fetched {courses.Count} students at {DateTime.Now}");

            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Add(course);
                _logger.LogInformation($"Created student with ID {course.Id} at {DateTime.Now}");

                return RedirectToAction("Index");
            }

            return View(course);
        }

        public IActionResult Edit(int id)
        {
            var student = _courseRepository.GetAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Update(course);
                _logger.LogInformation($"Updated student with ID {course.Id} at {DateTime.Now}");

                return RedirectToAction("Index");
            }

            return View(course);
        }

        public IActionResult Details(int id)
        {
            var student = _courseRepository.GetAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _courseRepository.GetAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _courseRepository.GetById(id);

            if (course != null)
            {
                _courseRepository.Remove(course);
                _logger.LogInformation($"Deleted student with ID {id} at {DateTime.Now}");
            }

            return RedirectToAction("Index");
        }

    }
}
