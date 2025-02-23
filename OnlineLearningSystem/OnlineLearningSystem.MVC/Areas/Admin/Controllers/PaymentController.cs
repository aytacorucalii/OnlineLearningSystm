using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Services.Abstractions;

namespace OnlineLearning.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class PaymentController : Controller
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    // Bütün ödənişləri göstərmək
    public async Task<IActionResult> Index()
    {
        var payments = await _paymentService.GetAllPaymentsAsync();
        return View(payments); // View-a bütün ödənişləri göndəririk
    }

    // Ödənişi göstərmək
    public async Task<IActionResult> Details(int id)
    {
        var payment = await _paymentService.GetPaymentByIdAsync(id);
        if (payment == null)
        {
            return NotFound(); // Əgər ödəniş tapılmadısa 404 səhifəsi qaytarırıq
        }

        return View(payment); // Ödənişi View-da göstəririk
    }

    // Yeni ödəniş yaratmaq
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PaymentDTO paymentDto)
    {
        if (ModelState.IsValid)
        {
            var createdPayment = await _paymentService.CreatePaymentAsync(paymentDto);
            if (createdPayment != null)
            {
                return RedirectToAction("Index"); // Yeni ödəniş yaratdıqdan sonra ana səhifəyə yönləndiririk
            }

            ModelState.AddModelError("", "Ödəniş yaratmaqda xəta baş verdi.");
        }

        return View(paymentDto); // Model səhv olarsa formu yenidən göstəririk
    }

    // Ödənişin statusunu yeniləmək
    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int id, bool status)
    {
        try
        {
            await _paymentService.UpdatePaymentStatusAsync(id, status);
            return RedirectToAction("Index"); // Statusu yenilədikdən sonra ana səhifəyə yönləndiririk
        }
        catch (ArgumentException)
        {
            return NotFound(); // Ödəniş tapılmadıqda 404 səhifəsi qaytarırıq
        }
    }

    // Ödənişi silmək
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _paymentService.DeletePaymentAsync(id);
        if (isDeleted)
        {
            return RedirectToAction("Index"); // Silindikdən sonra ana səhifəyə yönləndiririk
        }

        return NotFound(); // Ödəniş tapılmadıqda 404 səhifəsi qaytarırıq
    }
}
