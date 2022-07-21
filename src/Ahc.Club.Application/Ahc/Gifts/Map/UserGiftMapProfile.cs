using AutoMapper;
using Ahc.Club.Ahc.Gifts.Dto;

namespace Ahc.Club.Ahc.Gifts.Map
{
   public class UserGiftMapProfile : Profile
    {
        public UserGiftMapProfile()
        {
            CreateMap<UserGift, UserGiftDto>();
            CreateMap<UserGift, ReadUserGiftDto>();
            CreateMap<CreateUserGiftDto, UserGift>();
            CreateMap<UserGift, CreateUserGiftDto>();
            CreateMap<UpdateUserGiftDto, UserGift>();
            CreateMap<UserGift, UpdateUserGiftDto>();
        }
    }
}

