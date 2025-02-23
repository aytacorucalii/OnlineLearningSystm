using Microsoft.AspNetCore.Mvc;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.Core.Models;

namespace OnlineLearning.User.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IStripeService _stripeService;

        public PaymentController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession(Payment paymentSession)
        {
			if (paymentSession == null || paymentSession.Amount <= 0)
			{
				return View("Index", "home"); 
			}

			var sessionUrl = await _stripeService.CreateCheckoutSessionAsync(paymentSession);
            return Redirect(sessionUrl); // Redirect to Stripe checkout session URL
        }

        public IActionResult PaymentSuccess()
        {
            return View(); // Success view
        }

        public IActionResult PaymentCancel()
        {
            return View(); // Cancel view
        }
    }
}
