using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.BL.Services.Concretes;
using System.Reflection;

namespace OnlineLearning.DAL;

public static class ConfigurationServices
{
	public static void AddBLService(this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());

		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		services.AddFluentValidationAutoValidation();
		services.AddFluentValidationClientsideAdapters();

		services.AddScoped<IAccountService, AccountService>();
		services.AddScoped<ITeacherService, TeacherService>();
		services.AddScoped<IStudentService, StudentService>();
		services.AddScoped<ICourseService, CourseService>();
		services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IStripeService, StripeService>();
        services.AddScoped<IStatisticsService, StatisticsService>();
		services.AddScoped<IEmailService, EmailService>();
		services.AddScoped<ILayoutService, LayoutService>();
		services.AddScoped<IContactService , ContactService>();
	}
}