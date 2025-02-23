using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineLearning.BL.DTOs;

namespace OnlineLearning.BL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserLoginDTO, IdentityUser>().ReverseMap();
        CreateMap<UserRegisterDTO, IdentityUser>().ReverseMap();
    }
}
