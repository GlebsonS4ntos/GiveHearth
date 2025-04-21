using AutoMapper;
using GiveHearth.Dtos;
using GiveHearth.Models;

namespace GiveHearth.Config
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile() 
        { 
            CreateMap<Register, RegisterDto>().ReverseMap();
        }
    }
}
