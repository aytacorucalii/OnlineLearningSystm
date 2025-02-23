using FluentValidation;
using OnlineLearning.BL.DTOs;

namespace OnlineLearning.BL.Validations.UserValidations;

public class UserRegisterDTOValidation : AbstractValidator<UserRegisterDTO>
{
    public UserRegisterDTOValidation()
    {
        RuleFor(e => e.UserName)
            .NotEmpty().WithMessage("Username cannot be empty!")
            .MinimumLength(5).WithMessage("Username must be at least 5 symbols long!");

        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email cannot be empty!")
            .EmailAddress().WithMessage("Email address is wrong!");

        RuleFor(e => e.Password)
            .NotEmpty().WithMessage("Password cannot be empty!")
            .MinimumLength(4).WithMessage("Password must be at least 4 symbols long!");

        RuleFor(e => e.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm password cannot be empty!")
            .Equal(e => e.Password).WithMessage("Passwords don't match!");
    }
}