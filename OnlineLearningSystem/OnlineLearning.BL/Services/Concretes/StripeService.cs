using Stripe.Checkout;
using Stripe;
using OnlineLearning.Core.Models;
using OnlineLearning.BL.Services.Abstractions;

public class StripeService : IStripeService
{
	private readonly string _secretKey = "sk_test_51QurjPAcZDj7u3fW5CkwMtboWigeouKdi5jt9AJPHQHkEY6RqmBRCsWcBpQq7oyuAo8qsWN0Js1vfqhV5AbicwC700szKj9Qk1";

	public StripeService()
	{
		StripeConfiguration.ApiKey = _secretKey;
	}

	public async Task<string> CreateCheckoutSessionAsync(Payment paymentSession)
	{
		// Currency və Amount yoxlamaları
		if (string.IsNullOrEmpty(paymentSession.Currency))
		{
			throw new ArgumentException("Currency is required.");
		}

		if (paymentSession.Amount <= 0)
		{
			throw new ArgumentException("Amount should be greater than zero.");
		}

		var options = new SessionCreateOptions
		{
			PaymentMethodTypes = new List<string> { "card" },
			LineItems = new List<SessionLineItemOptions>
			{
				new SessionLineItemOptions
				{
					PriceData = new SessionLineItemPriceDataOptions
					{
						Currency = paymentSession.Currency.ToLower(), // Valyuta kodunu düzgün formatda göndəririk
                        UnitAmount = (long)(paymentSession.Amount * 100), // Stripe 100 bölünmüş formatı tələb edir
                        ProductData = new SessionLineItemPriceDataProductDataOptions
						{
							Name = "Order Payment"
						}
					},
					Quantity = 1
				}
			},
			Mode = "payment",
			SuccessUrl = paymentSession.SuccessUrl,
			CancelUrl = paymentSession.CancelUrl
		};

		var service = new SessionService();
		Session session = await service.CreateAsync(options);
		return session.Url;
	}
}
