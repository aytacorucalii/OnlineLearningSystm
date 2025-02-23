using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearningSystem.MVC.ViewModels;

namespace OnlineLearningSystem.MVC.Controllers;

public class TeacherController : Controller
{
	readonly ITeacherService _teacherService;
	readonly ICourseService _courseService;
	public TeacherController(ITeacherService teacherService, ICourseService courseService)
	{
		_teacherService = teacherService;
		_courseService = courseService;
	}
	public async Task<IActionResult> Index()
	{
		try
		{
			HomeVM VM = new()
			{
				Teachers = await _teacherService.GetTeacherViewItemsAsync(),
				Courses = await _courseService.GetCourseViewItemsAsync()
			};


			return View(VM);
		}
		catch (Exception)
		{
			return BadRequest("Something went wrong!");
		}
	}
}
