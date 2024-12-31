using AutoMapper;
using SignalROnionArchitecture.Application.Dtos.MenuTableDto;
using SignalROnionArchitecture.Application.Dtos.MessageDto;
using SignalROnionArchitecture.Core.Entities;

namespace SignalROnionArchitecture.Presentation.Api.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<CreateMessageDto, Message>().ReverseMap();
            CreateMap<ResultMessageDto, Message>().ReverseMap();
            CreateMap<GetByIdMessageDto, Message>().ReverseMap();
            CreateMap<UpdateMessageDto, Message>().ReverseMap();
        }
    }
}
