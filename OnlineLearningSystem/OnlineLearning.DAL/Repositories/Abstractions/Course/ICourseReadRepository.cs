using ListRace.DL.Repository.Abstractions;
using OnlineLearning.Core.Models;

namespace OnlineLearning.DAL.Repositories.Abstractions;

public interface ICourseReadRepository: IReadRepository<Course>
{
    IQueryable<Course> GetCourses();
    Task<List<Course>> SearchCoursesAsync(string searchTerm, int page = 1, int pageSize = 10, string sortBy = "CourseName");
}
