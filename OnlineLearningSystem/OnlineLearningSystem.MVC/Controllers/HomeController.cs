
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearningSystem.MVC.ViewModels;

namespace OnlineLearningSystem.MVC.Controllers;
public class HomeController : Controller
{
    readonly ITeacherService _teacherService;
	readonly ICourseService _courseService;
    readonly IStatisticsService _statisticsService;
    readonly IContactService _contactService;

	public HomeController(ICourseService courseService, ITeacherService teacherService, IStatisticsService statisticsService, IContactService contactService)
	{
		_courseService = courseService;
		_teacherService = teacherService;
		_statisticsService = statisticsService;
		_contactService = contactService;
	}

	public async Task<IActionResult> Index()
	{
        try
        {
            HomeVM VM = new()
            {
                Statistics = new List<StatisticsDTO> { await _statisticsService.GetStatisticsAsync() },
                Teachers = await _teacherService.GetTeacherViewItemsAsync(),
                Courses = await _courseService.GetCourseViewItemsAsync(),

                Messages = await _contactService.GetViewItemsAsync()
            };

			var courses = await _courseService.GetCourseListItemsAsync();
			ViewData["Courses"] = new SelectList(courses, "Id", "CourseName");

			return View(VM);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
     
    }
    public IActionResult Error()
    {
        return View();
    }
    public IActionResult GlobalException()
    {
        return View();
    }
}
