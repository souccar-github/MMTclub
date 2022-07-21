using AutoMapper;
using Ahc.Club.Ahc.Gifts.Dto;

namespace Ahc.Club.Ahc.Gifts.Map
{
   public class GiftMapProfile : Profile
    {
        public GiftMapProfile()
        {
            CreateMap<Gift, GiftDto>();
            CreateMap<Gift, ReadGiftDto>();
            CreateMap<CreateGiftDto, Gift>();
            CreateMap<Gift, CreateGiftDto>();
            CreateMap<UpdateGiftDto, Gift>();
            CreateMap<Gift, UpdateGiftDto>();
        }
    }
}

