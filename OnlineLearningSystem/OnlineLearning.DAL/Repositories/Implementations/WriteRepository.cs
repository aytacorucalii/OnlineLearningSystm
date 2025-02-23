using ListRace.DL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Core.Models.Base;
using OnlineLearning.DAL.Contexts;

namespace ListRace.DL.Repository.Implementations;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
{
	readonly AppDbContext _context;

	public WriteRepository(AppDbContext context)
	{
		_context = context;
	}
	public DbSet<T> Table => _context.Set<T>();
	public async Task CreateAsync(T entity)
	{
		entity.CreatedAt = DateTime.UtcNow.AddHours(4);
		await Table.AddAsync(entity);
	}

	public void Update(T entity)
	{
		entity.UpdatedAt = DateTime.UtcNow.AddHours(4);
		Table.Update(entity);
	}

	public void Delete(T entity)
	{
		Table.Remove(entity);
	}

	public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}


