using ListRace.DL.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Contexts;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.DAL.Repositories.Implementations;

public class StatisticsReadRepository : ReadRepository<Statistics>, IStatisticsReadRepository
{
	readonly AppDbContext _context;
    public StatisticsReadRepository(AppDbContext context) : base(context)
    {
		_context= context;
    }
	
	public async Task<Statistics> GetStatisticsAsync()
	{
		return await _context.Statistics.FirstOrDefaultAsync();
	}
}