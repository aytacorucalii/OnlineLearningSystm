using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;
using Stripe;

namespace OnlineLearningSystem.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ContactController : Controller
{
	readonly IContactService _service;

	public ContactController(IContactService service)
	{
		_service = service;
	}

	public async Task<IActionResult> Index()
	{
		ICollection<ContactDTO> messages = await _service.GetAllAsync();
		return View(messages);
	}

	public async Task<IActionResult> Details(int id)
	{
		ContactDTO? message = await _service.GetByIdAsync(id);
		if (message == null)
		{
			return NotFound();
		}

		return View(message);
	}

	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(ContactDTO messageCreateDto)
	{
		if (!ModelState.IsValid)
		{
			return View(messageCreateDto);
		}

		try
		{
			await _service.CreateAsync(messageCreateDto);
			await _service.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		catch (BaseException ex)
		{
			ModelState.AddModelError("CustomError", ex.Message);
			return View(messageCreateDto);
		}
		catch (Exception)
		{
			ModelState.AddModelError("CustomError", "Something went wrong!");
			return View(messageCreateDto);
		}
	}


	[HttpGet]
	public async Task<IActionResult> Update(int id)
	{
		ContactDTO? message = await _service.GetByIdAsync(id);
		if (message == null)
		{
			return NotFound();
		}

		ContactDTO messageUpdateDto = new ContactDTO
		{
			Id = id,
			Comment = message.Comment,
			Rating = message.Rating
		};

		return View(messageUpdateDto);
	}

	[HttpPost]
	public async Task<IActionResult> Update(ContactDTO messageUpdateDto)
	{
		//if (!ModelState.IsValid)
		//{
		//	return View(messageUpdateDto);
		//}

		bool updated = await _service.UpdateAsync(messageUpdateDto);
		if (!updated)
		{
			return NotFound();
		}

		await _service.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}


	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Delete(int id)
	{
		await _service.DeleteAsync(id);
		await _service.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
}
