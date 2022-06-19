using AutoMapper;
using Ahc.Club.Ahc.Indexes.Dto;

namespace Ahc.Club.Ahc.Indexes.Map
{
   public class SizeMapProfile : Profile
    {
        public SizeMapProfile()
        {
            CreateMap<Size, SizeDto>();
            CreateMap<Size, ReadSizeDto>();
            CreateMap<CreateSizeDto, Size>();
            CreateMap<Size, CreateSizeDto>();
            CreateMap<UpdateSizeDto, Size>();
            CreateMap<Size, UpdateSizeDto>();
        }
    }
}

