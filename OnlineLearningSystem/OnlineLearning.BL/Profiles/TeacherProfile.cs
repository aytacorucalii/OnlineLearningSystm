using AutoMapper;
using OnlineLearning.BL.DTOs;
using OnlineLearning.Core.Models;

namespace OnlineLearning.BL.Profiles;

public class TeacherProfile : Profile
{
	public TeacherProfile()
	{
		CreateMap<TeacherCreateDTO, Teacher>().ReverseMap();
		CreateMap<TeacherUpdateDTO, Teacher>().ReverseMap();
		CreateMap<TeacherListItemDTO, Teacher>().ReverseMap();
		CreateMap<TeacherViewItemDTO, Teacher>().ReverseMap();
	}
}
