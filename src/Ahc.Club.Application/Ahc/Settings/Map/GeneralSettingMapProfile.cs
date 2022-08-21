using AutoMapper;
using Ahc.Club.Ahc.Settings.Dto;

namespace Ahc.Club.Ahc.Settings.Map
{
   public class GeneralSettingMapProfile : Profile
    {
        public GeneralSettingMapProfile()
        {
            CreateMap<GeneralSetting, GeneralSettingDto>();
            CreateMap<GeneralSettingDto, GeneralSetting>();
            CreateMap<GeneralSetting, ReadGeneralSettingDto>();
            CreateMap<CreateGeneralSettingDto, GeneralSetting>();
            CreateMap<GeneralSetting, CreateGeneralSettingDto>();
            CreateMap<UpdateGeneralSettingDto, GeneralSetting>();
            CreateMap<GeneralSetting, UpdateGeneralSettingDto>();
        }
    }
}

