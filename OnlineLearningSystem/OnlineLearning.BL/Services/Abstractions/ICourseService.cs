using OnlineLearning.BL.DTOs;
using OnlineLearning.Core.Models;

namespace OnlineLearning.BL.Services.Abstractions;

public interface ICourseService
{
    Task<ICollection<CourseViewItemDTO>> GetCourseViewItemsAsync();
    Task<ICollection<CourseListItemDTO>> GetCourseListItemsAsync();
    Task<Course> GetByIdAsync(int id);
    Task<Course> GetByIdWithChildrenAsync(int id);
    Task<CourseUpdateDTO> GetByIdForUpdateAsync(int id);
    Task CreateAsync(CourseCreateDTO dto);
    Task UpdateAsync(CourseUpdateDTO dto);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
    Task<List<CourseListItemDTO>> SearchCoursesAsync(string searchTerm, int page = 1, int pageSize = 10, string sortBy = "CourseName");
}

