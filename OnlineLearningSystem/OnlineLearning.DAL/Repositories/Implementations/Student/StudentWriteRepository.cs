using ListRace.DL.Repository.Implementations;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Contexts;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.DAL.Repositories.Implementations;

public class StudentWriteRepository : WriteRepository<Student>, IStudentWriteRepository
{
    public StudentWriteRepository(AppDbContext context) : base(context)
    {
    }
}