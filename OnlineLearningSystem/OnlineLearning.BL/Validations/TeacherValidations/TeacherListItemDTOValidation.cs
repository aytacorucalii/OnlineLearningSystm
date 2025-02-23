using FluentValidation;
using OnlineLearning.BL.DTOs;

namespace OnlineLearning.BL.Validations.TeacherValidations;

public class TeacherListItemDTOValidation : AbstractValidator<TeacherListItemDTO>
{
    public TeacherListItemDTOValidation()
    {
        RuleFor(e => e.Id)
           .GreaterThan(0).WithMessage("Id must be a natural number!");
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

        RuleFor(e => e.ExperienceYears)
            .NotEmpty().WithMessage("ExperienceYears cannot be empty!")
            .GreaterThanOrEqualTo(1).WithMessage("ExperienceYears must be 1 or greater!")
            .LessThanOrEqualTo(60).WithMessage("ExperienceYears must be 60 or less than that!");
          //RuleFor(teacher => teacher.CourseName)
          //  .Must((teacher, courseName) => teacher.Courses.Any(c => c. == courseName))
          //  .WithMessage("Course name must match one of the teacher's courses.");
    }
}