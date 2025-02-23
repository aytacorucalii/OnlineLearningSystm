using FluentValidation;
using OnlineLearning.BL.DTOs;

namespace OnlineLearning.BL.Validations.StudentValidations;

public class StudentListItemDTOValidation : AbstractValidator<StudentListItemDTO>
{
    public StudentListItemDTOValidation()
    {
        RuleFor(e => e.Id)
              .GreaterThan(0).WithMessage("Id must be a natural number!");

        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Name cannot be empty!")
            .MinimumLength(2).WithMessage("Name must be at least 2 symbols long!")
            .MaximumLength(100).WithMessage("The length of the name cannot exceed 100 symbols!");

        RuleFor(e => e.Surname)
            .NotEmpty().WithMessage("Surname cannot be empty!")
            .MinimumLength(2).WithMessage("Surname must be at least 2 symbols long!")
            .MaximumLength(255).WithMessage("The length of the surname cannot exceed 255 symbols!");


    }
}