using ListRace.DL.Repository.Implementations;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Contexts;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.DAL.Repositories.Implementations;

public class StatisticsWriteRepository : WriteRepository<Statistics>, IStatisticsWriteRepository
{
    public StatisticsWriteRepository(AppDbContext context) : base(context)
    {
    }
}
