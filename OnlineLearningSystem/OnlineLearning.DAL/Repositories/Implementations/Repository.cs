using ListRace.DL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Core.Models.Base;
using OnlineLearning.DAL.Contexts;

namespace ListRace.DL.Repository.Implementations;

public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }
    public DbSet<T> Table => _context.Set<T>();

}


