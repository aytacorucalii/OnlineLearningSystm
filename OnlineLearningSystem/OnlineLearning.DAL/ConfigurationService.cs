using Microsoft.Extensions.DependencyInjection;
using OnlineLearning.DAL.Repositories.Abstractions;
using OnlineLearning.DAL.Repositories.Implementations;

namespace OnlineLearning.DAL;

public static class ConfigurationService
{
	public static void AddDALService(this IServiceCollection services)
	{
		services.AddScoped<ICourseReadRepository, CourseReadRepository>();
		services.AddScoped<ICourseWriteRepository, CourseWriteRepository>();
		services.AddScoped<ITeacherReadRepository, TeacherReadRepository>();
		services.AddScoped<ITeacherWriteRepository, TeacherWriteRepository>();
		services.AddScoped<IStudentReadRepository, StudentReadRepository>();
		services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();
        services.AddScoped<IStatisticsReadRepository, StatisticsReadRepository>();
        services.AddScoped<IStatisticsWriteRepository, StatisticsWriteRepository>();
		services.AddScoped<IContactReadRepository, ContactReadRepository>();
		services.AddScoped<IContactWriteRepository, ContactWriteRepository>();
    }
}
