//using AutoMapper;
//using RocketAPI.Models;
//using RocketDomain.Entities;

//namespace RocketAPI.Utilities
//{
    //public class AutoMapperProfiles : Profile
    //{
    //    public AutoMapperProfiles()
    //    {
    //CreateMap<RocketModel, Rocket>()
    //    .ForMember(r => r.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
    //    .ReverseMap();

//CreateMap<Rocket, RocketModel>()
//    .ForMember(r => r.Id, opt => opt.MapFrom(src => src.Id.ToString()))
//    .ReverseMap();
//        }
//    }
//}
