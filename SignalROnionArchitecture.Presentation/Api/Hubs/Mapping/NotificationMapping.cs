using AutoMapper;
using SignalROnionArchitecture.Application.Dtos.NotificationDto;
using SignalROnionArchitecture.Core.Entities;

namespace SignalROnionArchitecture.Presentation.Api.Hubs.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<ResultNotificationDto, Notification>().ReverseMap();
            CreateMap<CreateNotificationDto, Notification>().ReverseMap();
            CreateMap<GetByIdNotificationDto, Notification>().ReverseMap();
            CreateMap<UpdateNotificationDto, Notification>().ReverseMap();
        }
    }
}
