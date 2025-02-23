using ListRace.DL.Repository.Implementations;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Contexts;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.DAL.Repositories.Implementations;

public class StudentReadRepository : ReadRepository<Student>, IStudentReadRepository
{
    public StudentReadRepository(AppDbContext context) : base(context)
    {
    }
}
