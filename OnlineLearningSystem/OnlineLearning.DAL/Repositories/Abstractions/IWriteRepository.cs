using OnlineLearning.Core.Models.Base;

namespace ListRace.DL.Repository.Abstractions;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
{
	Task CreateAsync(T entity);
	void Update(T entity);
	void Delete(T entity);
	Task<int> SaveChangesAsync();
}
