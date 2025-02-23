using OnlineLearning.BL.DTOs;
using OnlineLearning.Core.Models;

namespace OnlineLearning.BL.Services.Abstractions;

public interface ITeacherService
{
	Task<ICollection<TeacherViewItemDTO>> GetTeacherViewItemsAsync();
	Task<ICollection<TeacherListItemDTO>> GetTeacherListItemsAsync();
	Task<Teacher> GetByIdAsync(int id);
	Task<Teacher> GetByIdWithChildrenAsync(int id);
	Task<TeacherUpdateDTO> GetByIdForUpdateAsync(int id);
	Task CreateAsync(TeacherCreateDTO dto);
	Task UpdateAsync(TeacherUpdateDTO dto);
	Task DeleteAsync(int id);
	Task<int> SaveChangesAsync();
}
