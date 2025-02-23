using OnlineLearning.BL.DTOs;
using OnlineLearning.Core.Models;

namespace OnlineLearning.BL.Services.Abstractions;

public interface IStudentService
{
    Task<ICollection<StudentViewItemDTO>> GetStudentViewItemsAsync();
    Task<ICollection<StudentListItemDTO>> GetStudentListItemsAsync();
    Task<Student> GetByIdAsync(int id);
    Task<Student> GetByIdWithChildrenAsync(int id);
    Task<StudentUpdateDTO> GetByIdForUpdateAsync(int id);
    Task CreateAsync(StudentCreateDTO dto);
    Task UpdateAsync(StudentUpdateDTO dto);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
