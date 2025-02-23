using FluentValidation;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Utilities;

namespace OnlineLearning.BL.Validations.StudentValidations;

public class StudentCreateDTOValidation : AbstractValidator<StudentCreateDTO>
{
    public StudentCreateDTOValidation()
    {
       
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Name cannot be empty!")
            .MinimumLength(2).WithMessage("Name must be at least 2 symbols long!")
            .MaximumLength(100).WithMessage("The length of the name cannot exceed 100 symbols!");

        RuleFor(e => e.Surname)
            .NotEmpty().WithMessage("Surname cannot be empty!")
            .MinimumLength(2).WithMessage("Surname must be at least 2 symbols long!")
            .MaximumLength(255).WithMessage("The length of the surname cannot exceed 255 symbols!");

        RuleFor(x => x.Image)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Image cannot be null!")
            .Must(x => x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!")
            .Must(x => x.ContentType.StartsWith("image/")).WithMessage("File must be an image!");
    }
}