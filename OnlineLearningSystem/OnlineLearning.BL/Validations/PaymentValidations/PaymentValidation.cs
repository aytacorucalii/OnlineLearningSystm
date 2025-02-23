using FluentValidation;
using OnlineLearning.BL.DTOs;

namespace OnlineLearningSystem.MVC.Areas.Admin.Models.Validators
{
	public class PaymentDtoValidator : AbstractValidator<PaymentDTO>
	{
		public PaymentDtoValidator()
		{
			RuleFor(x => x.Amount)
				.GreaterThan(0).WithMessage("Məbləğ müsbət olmalıdır.");

			RuleFor(x => x.Status)
				.NotEmpty().WithMessage("Status boş olmamalıdır.");

			RuleFor(x => x.PaymentDate)
				.NotEmpty().WithMessage("Ödəniş tarixi boş olmamalıdır.");
		}
	}
}
