using Microsoft.Extensions.Configuration;
using OnlineLearning.BL.Services.Abstractions;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OnlineLearning.BL.Services.Concretes;

public class EmailService : IEmailService
{
	private readonly IConfiguration _configuration;

	public EmailService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	private void Send(string toUser, string subject, string body, bool isHtml)
	{
		SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]))
		{
			EnableSsl = true,
			Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"])
		};

		MailMessage message = new MailMessage(
			new MailAddress("aytacho-ab205@code.edu.az"),
			new MailAddress(toUser))
		{
			Subject = subject,
			Body = body,
			IsBodyHtml = isHtml
		};

		smtp.Send(message);
	}

	public void SendEmail(string toUser)
	{
		Send(toUser, "Hello from Online Learning System", "Welcome to Our Page", false);
	}

	public void SendEmailConfirm(string toUser, string confirmUrl)
	{
		Send(toUser, "Confirm Email", $"<a href={confirmUrl}> Click here </a>", true);
	}
}