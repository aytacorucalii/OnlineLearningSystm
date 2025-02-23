using FluentValidation;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Utilities;

namespace OnlineLearning.BL.Validations.TeacherValidations;

public class TeacherCreateDTOValidation : AbstractValidator<TeacherCreateDTO>
{
    public TeacherCreateDTOValidation()
    {
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Name cannot be empty!")
            .MinimumLength(2).WithMessage("Name must be at least 2 symbols long!")
            .MaximumLength(100).WithMessage("The length of the name cannot exceed 100 symbols!");

        RuleFor(e => e.Subject)
            .NotEmpty().WithMessage("Subject cannot be empty!")
            .MinimumLength(2).WithMessage("Subject must be at least 2 symbols long!")
            .MaximumLength(255).WithMessage("The length of the subject cannot exceed 255 symbols!");

        RuleFor(e => e.Surname)
            .NotEmpty().WithMessage("Surname cannot be empty!")
            .MinimumLength(2).WithMessage("Surname must be at least 2 symbols long!")
            .MaximumLength(255).WithMessage("The length of the surname cannot exceed 255 symbols!");

        RuleFor(e => e.Salary)
            .NotEmpty().WithMessage("Salary cannot be empty!")
            .GreaterThanOrEqualTo(400).WithMessage("Salary must be 400 or greater!")
            .LessThanOrEqualTo(99999999.99m).WithMessage("Salary must be 99999999.99 or less than that!");

        RuleFor(e => e.ExperienceYears)
            .NotEmpty().WithMessage("ExperienceYears cannot be empty!")
            .GreaterThanOrEqualTo(1).WithMessage("ExperienceYears must be 1 or greater!")
            .LessThanOrEqualTo(60).WithMessage("ExperienceYears must be 60 or less than that!");

        RuleFor(x => x.Image)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Image cannot be null!")
            .Must(x => x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
            .Must(x => x.ContentType.StartsWith("image/")).WithMessage("File must be an image!");

    }
}