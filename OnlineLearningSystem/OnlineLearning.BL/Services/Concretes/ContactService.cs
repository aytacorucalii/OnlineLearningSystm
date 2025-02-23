using AutoMapper;
using OnlineLearning.BL.DTOs;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.Core.Models;
using OnlineLearning.DAL.Repositories.Abstractions;

namespace OnlineLearning.BL.Services.Concretes;

public class ContactService : IContactService
{
    readonly IMapper _mapper;
    readonly IContactReadRepository _readRepo;
    readonly IContactWriteRepository _writeRepo;

    public ContactService(IContactWriteRepository writeRepo, IContactReadRepository readRepo, IMapper mapper)
    {
        _writeRepo = writeRepo;
        _readRepo = readRepo;
        _mapper = mapper;
    }

	public async Task<ICollection<ContactDTO>> GetViewItemsAsync() => _mapper.Map<ICollection<ContactDTO>>(await _readRepo.GetAllAsync());

	public async Task<ICollection<ContactDTO>> GetAllAsync()
	{
		ICollection<Contact> Contacts = (await _readRepo.GetAllAsync()).ToList();
		ICollection<ContactDTO> ContactDtos = _mapper.Map<ICollection<ContactDTO>>(Contacts);
		return ContactDtos;
	}

	public async Task<ContactDTO?> GetByIdAsync(int id)
	{
		Contact? Contact = await _readRepo.GetByIdAsync(id);
		if (Contact == null)
		{
			return null;
		}

		ContactDTO ContactDto = _mapper.Map<ContactDTO>(Contact);
		return ContactDto;
	}

	public async Task CreateAsync(ContactDTO ContactCreateDto)
	{
		Contact Contact = _mapper.Map<Contact>(ContactCreateDto);
		await _writeRepo.CreateAsync(Contact);
	}

	public async Task UserCreateAsync(ContactDTO userCreateDto,string UserName)
	{
		Contact Contact = _mapper.Map<Contact>(userCreateDto);
		Contact.UserName = UserName;
		await _writeRepo.CreateAsync(Contact);
	}

	public async Task<bool> UpdateAsync(ContactDTO ContactUpdateDto)
	{

		Contact? existingContact = await _readRepo.GetByIdAsync(ContactUpdateDto.Id);
		if (existingContact == null)
		{
			return false;
		}

		existingContact.Comment = ContactUpdateDto.Comment;
		existingContact.Rating = ContactUpdateDto.Rating;

		_writeRepo.Update(existingContact);
		return true;
	}
	public async Task<bool> DeleteAsync(int id)
	{
		Contact? Contact = await _readRepo.GetByIdAsync(id);
		if (Contact == null)
		{
			return false;
		}

		_writeRepo.Delete(Contact);
		return true;
	}

	public async Task<int> SaveChangesAsync() => await _writeRepo.SaveChangesAsync();
}