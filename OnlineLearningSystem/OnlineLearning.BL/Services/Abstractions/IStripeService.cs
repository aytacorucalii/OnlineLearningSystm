using OnlineLearning.Core.Models;

namespace OnlineLearning.BL.Services.Abstractions;

public interface IStripeService
{
	Task<string> CreateCheckoutSessionAsync(Payment paymentSession);
}