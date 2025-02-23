using FluentValidation;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Utilities;

namespace OnlineLearning.BL.Validations.CourseValidations;

public class CourseUpdateDTOValidation : AbstractValidator<CourseUpdateDTO>
{
    public CourseUpdateDTOValidation()
    {
        RuleFor(e => e.Id)
            .GreaterThan(0).WithMessage("Id must be a natural number!");
      RuleFor(e => e.CourseName)
            .NotEmpty().WithMessage("CourseName cannot be empty!")
            .MinimumLength(2).WithMessage("CourseName must be at least 2 symbols long!")
            .MaximumLength(100).WithMessage("The length of the course name cannot exceed 100 symbols!");

        RuleFor(e => e.Description)
            .NotEmpty().WithMessage("Description cannot be empty!")
            .MinimumLength(2).WithMessage("Description must be at least 2 symbols long!")
            .MaximumLength(255).WithMessage("The length of the description cannot exceed 255 symbols!");

        RuleFor(e => e.Price)
            .NotEmpty().WithMessage("Price cannot be empty!")
            .GreaterThanOrEqualTo(400).WithMessage("Price must be 400 or greater!")
            .LessThanOrEqualTo(99999999.99m).WithMessage("Price must be 99999999.99 or less than that!");

        RuleFor(x => x.Image)
            .Must(x => x is null || x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
            .Must(x => x is null || x.CheckType("image")).WithMessage("File must be image!");
    }
}