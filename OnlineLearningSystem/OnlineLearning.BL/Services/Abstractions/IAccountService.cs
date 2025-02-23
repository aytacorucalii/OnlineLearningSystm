using OnlineLearning.BL.DTOs;

namespace OnlineLearning.BL.Services.Abstractions;

public interface IAccountService
{
	Task RegisterAsync(UserRegisterDTO dto);
	Task LoginAsync(UserLoginDTO dto);
	Task LogoutAsync();
}
