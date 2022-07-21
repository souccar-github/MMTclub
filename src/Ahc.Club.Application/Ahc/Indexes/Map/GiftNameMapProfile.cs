using AutoMapper;
using Ahc.Club.Ahc.Indexes.Dto;

namespace Ahc.Club.Ahc.Indexes.Map
{
   public class GiftNameMapProfile : Profile
    {
        public GiftNameMapProfile()
        {
            CreateMap<GiftName, GiftNameDto>();
            CreateMap<GiftName, ReadGiftNameDto>();
            CreateMap<CreateGiftNameDto, GiftName>();
            CreateMap<GiftName, CreateGiftNameDto>();
            CreateMap<UpdateGiftNameDto, GiftName>();
            CreateMap<GiftName, UpdateGiftNameDto>();
        }
    }
}

