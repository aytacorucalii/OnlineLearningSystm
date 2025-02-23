using AutoMapper;
using OnlineLearning.BL.DTOs;
using OnlineLearning.Core.Models;

namespace OnlineLearning.BL.Profiles;

public class StudentProfile : Profile
{
	public StudentProfile()
	{
		CreateMap<StudentCreateDTO, Student>().ReverseMap();
		CreateMap<StudentUpdateDTO, Student>().ReverseMap();
		CreateMap<StudentListItemDTO, Student>().ReverseMap();
		CreateMap<StudentViewItemDTO, Student>().ReverseMap();
	}
}
