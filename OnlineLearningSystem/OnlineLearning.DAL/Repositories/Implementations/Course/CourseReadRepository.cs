using ListRace.DL.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Contexts;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.DAL.Repositories.Implementations;

public class CourseReadRepository : ReadRepository<Course>, ICourseReadRepository
{
    readonly AppDbContext _context;
	public CourseReadRepository(AppDbContext context) : base(context)
	{
        _context = context;
	}
    public IQueryable<Course> GetCourses()
    {
        return _context.Courses.AsNoTracking();
    }

   public async Task<List<Course>> SearchCoursesAsync(string searchTerm, int page = 1, int pageSize = 10, string sortBy = "CourseName")
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return new List<Course>();
        }

        var query = _context.Courses
            .Where(c => c.CourseName.Contains(searchTerm) || c.Description.Contains(searchTerm));

        if (sortBy.ToLower() == "coursename")
        {
            query = query.OrderBy(c => c.CourseName);
        }
        else
        {
            query = query.OrderBy(c => c.Description);
        }

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}

