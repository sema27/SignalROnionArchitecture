using AutoMapper;
using SignalROnionArchitecture.Application.Dtos.SocialMediaDto;
using SignalROnionArchitecture.Core.Entities;

namespace SignalROnionArchitecture.Presentation.Api.Mapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
        }
    }
}
