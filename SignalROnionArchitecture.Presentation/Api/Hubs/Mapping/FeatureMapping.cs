using AutoMapper;
using SignalROnionArchitecture.Application.Dtos.FeatureDto;
using SignalROnionArchitecture.Core.Entities;

namespace SignalROnionArchitecture.Presentation.Api.Hubs.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureDto>().ReverseMap();
        }
    }
}
