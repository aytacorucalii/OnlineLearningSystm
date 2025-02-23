using FluentValidation;
using OnlineLearning.BL.DTOs;

namespace OnlineLearning.BL.Validations.ContactValidations;

public class ContactDTOValidator : AbstractValidator<ContactDTO>
{
    public ContactDTOValidator()
	{
		//RuleFor(e => e.Id)
		//   .GreaterThan(0).WithMessage("Id must be a natural number!");


		//RuleFor(x => x.UserName)
		//	.MaximumLength(100).WithMessage("Username must not be longer than 100 characters.");

		RuleFor(x => x.Comment)
			.NotEmpty().WithMessage("Comment cannot be empty!")
			.MaximumLength(1000).WithMessage("The comment can be a maximum of 1000 characters.");

		RuleFor(x => x.Rating)
			.InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

		RuleFor(x => x.CourseId)
			.GreaterThan(0).WithMessage("course ID must be greater than 0.");

	}
}