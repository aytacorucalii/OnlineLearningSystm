
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Core.Models.Base;

namespace ListRace.DL.Repository.Abstractions;

public interface IRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }
}
