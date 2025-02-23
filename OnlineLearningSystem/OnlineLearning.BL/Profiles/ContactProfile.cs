using AutoMapper;
using OnlineLearning.BL.DTOs;
using OnlineLearning.Core.Models;

namespace OnlineLearning.BL.Profiles;

public class ContactProfile : Profile
{
	public ContactProfile()
	{
		CreateMap<ContactDTO, Contact>().ReverseMap();

	}
}