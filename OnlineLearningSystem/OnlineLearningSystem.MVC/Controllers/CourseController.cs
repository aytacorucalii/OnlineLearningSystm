using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.Core.Models;
using OnlineLearningSystem.MVC.ViewModels;

namespace OnlineLearningSystem.MVC.Controllers
{
    public class CourseController : Controller
    {
        readonly ITeacherService _teacherService;
        readonly ICourseService _courseService;

        public CourseController(ITeacherService teacherService, ICourseService courseService)
        {
            _teacherService = teacherService;
            _courseService = courseService;
        }

        public async Task<IActionResult> Index(string searchTerm, int page = 1, int pageSize = 10, string sortBy = "CourseName")
        {
            try
            {
                var courses = await _courseService.SearchCoursesAsync(searchTerm, page, pageSize, sortBy);

                HomeVM VM = new()
                {
                    Teachers = await _teacherService.GetTeacherViewItemsAsync(),
                    Courses =  await _courseService.GetCourseViewItemsAsync()
                };

                ViewData["Courses"] = VM.Courses;

                return View(VM);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchCourses(string searchTerm, int page = 1, int pageSize = 10)
        {
            if (page < 1 || pageSize < 1)
            {
                return BadRequest("Səhifə dəyəri düzgün deyil");
            }

            var courses = await _courseService.SearchCoursesAsync(searchTerm, page, pageSize);

            return Ok(courses);
        }
    }
}
