
namespace OnlineLearning.BL.Services.Abstractions;
public interface IEmailService
{
	void SendEmail(string toUser);
	void SendEmailConfirm(string toUser, string confirmUrl);
}
