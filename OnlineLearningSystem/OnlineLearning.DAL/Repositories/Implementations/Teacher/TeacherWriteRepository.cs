using ListRace.DL.Repository.Implementations;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Contexts;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.DAL.Repositories.Implementations;

public class TeacherWriteRepository : WriteRepository<Teacher>, ITeacherWriteRepository
{
    public TeacherWriteRepository(AppDbContext context) : base(context)
    {
    }
}
