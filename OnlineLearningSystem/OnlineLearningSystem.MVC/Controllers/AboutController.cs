using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningSystem.MVC.Controllers;

public class AboutController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
