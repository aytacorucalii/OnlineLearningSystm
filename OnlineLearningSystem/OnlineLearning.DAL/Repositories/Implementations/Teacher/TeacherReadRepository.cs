using ListRace.DL.Repository.Implementations;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Contexts;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.DAL.Repositories.Implementations;

public class TeacherReadRepository : ReadRepository<Teacher>, ITeacherReadRepository
{
    public TeacherReadRepository(AppDbContext context) : base(context)
    {
    }
}
