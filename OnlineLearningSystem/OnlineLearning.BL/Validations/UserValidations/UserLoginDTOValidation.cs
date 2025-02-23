using FluentValidation;
using OnlineLearning.BL.DTOs;

namespace OnlineLearning.BL.Validations.UserValidations;

public class UserLoginDTOValidation : AbstractValidator<UserLoginDTO>
{
    public UserLoginDTOValidation()
    {
        RuleFor(e => e.UserName)
            .NotEmpty().WithMessage("Username cannot be empty!")
            .MinimumLength(5).WithMessage("Username must be at least 5 symbols long!");

        RuleFor(e => e.Password)
            .NotEmpty().WithMessage("Password cannot be empty!")
            .MinimumLength(4).WithMessage("Password must be at least 4 symbols long!");

    }
}