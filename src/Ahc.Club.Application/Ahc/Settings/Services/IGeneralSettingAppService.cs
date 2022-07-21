using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Ahc.Club.Ahc.Settings.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Ahc.Club.Ahc.Settings.Services
{
    public interface IGeneralSettingAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<GeneralSettingDto>> GetAllAsync();
        Task<GeneralSettingDto> GetByIdAsync(int id);
        Task<UpdateGeneralSettingDto> GetForEditAsync(int id);
        Task<CreateGeneralSettingDto> CreateAsync(CreateGeneralSettingDto generalSetting);
        Task<UpdateGeneralSettingDto> UpdateAsync(UpdateGeneralSettingDto generalSetting);
        Task DeleteAsync(int id);
    }
}

