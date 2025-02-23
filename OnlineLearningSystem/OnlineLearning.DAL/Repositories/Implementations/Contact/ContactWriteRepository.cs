using ListRace.DL.Repository.Implementations;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Contexts;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.DAL.Repositories.Implementations;

public class ContactWriteRepository : WriteRepository<Contact>, IContactWriteRepository
{
    public ContactWriteRepository(AppDbContext context) : base(context)
    {
    }
}
