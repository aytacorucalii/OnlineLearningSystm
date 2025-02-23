using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Repositories.Abstractions;
using System.Threading.Tasks;

namespace OnlineLearning.BL.Services.Concretes
{
	public class StatisticsService : IStatisticsService
	{
		private readonly IStatisticsReadRepository _readRepository;
		private readonly IStatisticsWriteRepository _writeRepository;

		public StatisticsService(IStatisticsReadRepository readRepository, IStatisticsWriteRepository writeRepository)
		{
			_readRepository = readRepository;
			_writeRepository = writeRepository;
		}

		// ✅ Mövcud statistik məlumatı gətirir
		public async Task<StatisticsDTO> GetStatisticsAsync()
		{
			var statistics = await _readRepository.GetStatisticsAsync();
			return statistics != null
				? new StatisticsDTO
				{
					StudentCount = statistics.StudentCount,
					TeacherCount = statistics.TeacherCount,
					CourseCount = statistics.LearningProgramCount
				}
				: new StatisticsDTO { StudentCount = 0, TeacherCount = 0, CourseCount = 0 };
		}

		// ✅ StudentCount 1 artır
		public async Task IncrementStudentCount()
		{
			await IncrementStatistics(statistics => statistics.StudentCount++);
		}

		// ✅ TeacherCount 1 artır
		public async Task IncrementTeacherCount()
		{
			await IncrementStatistics(statistics => statistics.TeacherCount++);
		}

		// ✅ CourseCount 1 artır
		public async Task IncrementCourseCount()
		{
			await IncrementStatistics(statistics => statistics.LearningProgramCount++);
		}

		// 🔥 Private helper metod (təkrarı aradan qaldırır)
		private async Task IncrementStatistics(Action<Statistics> incrementAction)
		{
			var statistics = await _readRepository.GetStatisticsAsync();
			if (statistics == null)
			{
				statistics = new Statistics
				{
					StudentCount = 0,
					TeacherCount = 0,
					LearningProgramCount = 0
				};
			}

			incrementAction(statistics); // Məs: statistics.StudentCount++

			 _writeRepository.Update(statistics);
		}
	}
}
