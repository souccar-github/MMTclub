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
            CreateMap<Gift, CreateGiftDto>().ForMember(m => m.Image, a => a.Ignore());
            CreateMap<UpdateGiftDto, Gift>().ForMember(m => m.Image, a => a.Ignore());
            CreateMap<Gift, UpdateGiftDto>().ForMember(m => m.Image, a => a.Ignore());
        }
    }
}

