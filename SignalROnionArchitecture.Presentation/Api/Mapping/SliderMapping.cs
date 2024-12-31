using AutoMapper;
using SignalROnionArchitecture.Application.Dtos.SliderDto;
using SignalROnionArchitecture.Core.Entities;

namespace SignalROnionArchitecture.Presentation.Api.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
            CreateMap<Slider, GetByIdSliderDto>().ReverseMap();
        }
    }
}
