using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Exceptions;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.Core.Enums;

namespace OnlineLearningSystem.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class AccountController : Controller
{
	readonly IAccountService _service;
	readonly IEmailService _emailService;

	public AccountController(IAccountService service, IEmailService emailService)
	{
		_service = service;
		_emailService = emailService;
	}

	public IActionResult Login()
	{
		if (User.Identity is not null && User.Identity.IsAuthenticated)
			return Redirect(User.IsInRole(Roles.Admin.ToString()) ? "/admin/dashboard" : "/");

		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Login(UserLoginDTO dto, string? returnUrl = null)
	{
		if (!ModelState.IsValid)
		{
			return View(dto);
		}

		try
		{
			await _service.LoginAsync(dto);
		}
		catch (BaseException ex)
		{
			ModelState.AddModelError("CustomError", ex.Message);
			return View(dto);
		}
		catch (Exception)
		{
			ModelState.AddModelError("CustomError", "Something went wrong!");
			return View(dto);
		}

		return Redirect(returnUrl ?? (User.IsInRole(Roles.Admin.ToString()) ? "/admin/dashboard" : "/"));
	}

	public IActionResult Register()
	{
		if (User.Identity is not null && User.Identity.IsAuthenticated)
			return Redirect(User.IsInRole(Roles.Admin.ToString()) ? "/admin/dashboard" : "/");

		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Register(UserRegisterDTO dto)
	{
		if (!ModelState.IsValid)
		{
			return View(dto);
		}

		try
		{
			await _service.RegisterAsync(dto);

			// Email təsdiq linki yarat
			string confirmUrl = Url.Action("ConfirmEmail", "Account", new { email = dto.Email }, Request.Scheme);

			// Email təsdiq mesajını göndər
			_emailService.SendEmailConfirm(dto.Email, confirmUrl);
		}
		catch (BaseException ex)
		{
			ModelState.AddModelError("CustomError", ex.Message);
			return View(dto);
		}
		catch (Exception)
		{
			ModelState.AddModelError("CustomError", "Something went wrong!");
			return View(dto);
		}

		return Redirect("/admin/account/login");
	}

	public async Task<IActionResult> Logout()
	{
		try
		{
			await _service.LogoutAsync();
			return Redirect("/");
		}
		catch (Exception)
		{
			return BadRequest("Something went wrong!");
		}
	}
}
