using OnlineLearning.BL.DTOs;

namespace OnlineLearning.BL.Services.Abstractions;

public interface IContactService
{
	Task<ICollection<ContactDTO>> GetViewItemsAsync();
	Task<ICollection<ContactDTO>> GetAllAsync();
	Task<ContactDTO?> GetByIdAsync(int id);
	Task CreateAsync(ContactDTO messageCreateDto);
	Task UserCreateAsync(ContactDTO userCreateDto, string UserName);
	Task<bool> UpdateAsync(ContactDTO messageUpdateDto);
	Task<bool> DeleteAsync(int id);
	Task<int> SaveChangesAsync();
}