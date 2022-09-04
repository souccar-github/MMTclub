using AutoMapper;
using Ahc.Club.Ahc.Levels.Dto;
using Ahc.Club.Users.Dto;

namespace Ahc.Club.Ahc.Levels.Map
{
   public class LevelMapProfile : Profile
    {
        public LevelMapProfile()
        {
            CreateMap<Level, LevelDto>();
            CreateMap<Level, ReadLevelDto>();
            CreateMap<CreateLevelDto, Level>();
            CreateMap<Level, CreateLevelDto>();
            CreateMap<UpdateLevelDto, Level>();
            CreateMap<Level, UpdateLevelDto>();
            CreateMap<LevelDto, UserProfileLevelDto>().ForMember(x => x.Gifts, m => m.Ignore());
        }
    }
}

