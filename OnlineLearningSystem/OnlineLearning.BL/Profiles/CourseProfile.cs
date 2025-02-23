using AutoMapper;
using OnlineLearning.Core.Models;

namespace OnlineLearning.BL.Profiles;

public class CourseProfile : Profile
{
	public CourseProfile()
	{
		CreateMap<CourseCreateDTO, Course>().ReverseMap();
		CreateMap<CourseUpdateDTO, Course>().ReverseMap();
		CreateMap<CourseListItemDTO, Course>().ReverseMap();
		CreateMap<CourseViewItemDTO, Course>().ReverseMap();
	}
}
