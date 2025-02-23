using ListRace.DL.Repository.Abstractions;
using OnlineLearning.Core.Models;

namespace OnlineLearning.DAL.Repositories.Abstractions;

public interface IStatisticsReadRepository : IReadRepository<Statistics>
{
	Task<Statistics> GetStatisticsAsync();
}
