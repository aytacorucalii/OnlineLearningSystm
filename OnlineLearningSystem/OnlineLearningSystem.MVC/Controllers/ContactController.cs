using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Services.Abstractions;

namespace OnlineLearningSystem.MVC.Controllers;

public class ContactController : Controller
{
	readonly IContactService _service;
    readonly ICourseService _courseService;
    readonly IMapper _mapper;
    public ContactController(IContactService service, IMapper mapper, ICourseService courseService)
    {
        _service = service;
        _mapper = mapper;
        _courseService = courseService;
    }
	public async Task<IActionResult> Index()
	{
		var course = await _courseService.GetCourseListItemsAsync();
		ViewData["Course"] = new SelectList(course, "Id", "CourseName");

		return View();
	}
	[HttpGet]
	public async Task<IActionResult> Create()
	{
		var courses = await _courseService.GetCourseListItemsAsync();
		ViewData["Courses"] = new SelectList(courses, "Id", "CourseName");

		return View();
	}


	[HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ContactDTO dto)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return Unauthorized();
        }


        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index", "Home");
        }

        await _service.UserCreateAsync(dto,
            User.Identity.Name
        );
        await _service.SaveChangesAsync();

        TempData["SuccessMessage"] = "Your message has been submitted successfully!";
        return RedirectToAction("Index", "Home");
    }
}
