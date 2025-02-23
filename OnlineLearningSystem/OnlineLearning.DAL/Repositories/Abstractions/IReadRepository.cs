using OnlineLearning.Core.Models.Base;

namespace ListRace.DL.Repository.Abstractions;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
{
	Task<ICollection<T>> GetAllAsync(params string[] includes);
	Task<T?> GetByIdAsync(int id, params string[] includes);
}
