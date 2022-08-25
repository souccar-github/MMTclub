using AutoMapper;
using Ahc.Club.Ahc.Notifications.Dto;

namespace Ahc.Club.Ahc.Notifications.Map
{
   public class FcmNotificationMapProfile : Profile
    {
        public FcmNotificationMapProfile()
        {
            CreateMap<FcmNotification, FcmNotificationDto>();
            CreateMap<FcmNotification, ReadFcmNotificationDto>();
            CreateMap<CreateFcmNotificationDto, FcmNotification>();
            CreateMap<FcmNotification, CreateFcmNotificationDto>();
            CreateMap<UpdateFcmNotificationDto, FcmNotification>();
            CreateMap<FcmNotification, UpdateFcmNotificationDto>();
        }
    }
}

