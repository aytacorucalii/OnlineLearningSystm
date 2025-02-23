using ListRace.DL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Core.Models.Base;
using OnlineLearning.DAL.Contexts;

namespace ListRace.DL.Repository.Implementations;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
{
	readonly AppDbContext _context;

	public ReadRepository(AppDbContext context)
	{
		_context = context;
	}
	public DbSet<T> Table => _context.Set<T>();
	public async Task<ICollection<T>> GetAllAsync(params string[] includes)
	{
		IQueryable<T> query = Table;

		if (includes.Length > 0)
		{
			foreach (string include in includes)
			{
				query = query.Include(include);
			}
		}

		return await query.ToListAsync();
	}

	public async Task<T?> GetByIdAsync(int id, params string[] includes)
	{
		IQueryable<T> query = Table;

		if (includes.Length > 0)
		{
			foreach (string include in includes)
			{
				query = query.Include(include);
			}
		}

		return await query.SingleOrDefaultAsync(e => e.Id == id);
	}

}


