
namespace OnlineLearning.BL.Services.Abstractions;
public interface IStatisticsService
{
	Task<StatisticsDTO> GetStatisticsAsync();
	Task IncrementStudentCount();
	Task IncrementTeacherCount();
	Task IncrementCourseCount();
}

