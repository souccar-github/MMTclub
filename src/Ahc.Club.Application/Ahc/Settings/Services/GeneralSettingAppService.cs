using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahc.Club.Ahc.Settings.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Ahc.Club.Ahc.Settings.Services
{
    public class GeneralSettingAppService : ExchangeAppServiceBase, IGeneralSettingAppService
    {
        private readonly IGeneralSettingDomainService _generalSettingDomainService;
        public GeneralSettingAppService(IGeneralSettingDomainService generalSettingDomainService)
        {
            _generalSettingDomainService = generalSettingDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _generalSettingDomainService.Get().ToList();
            IEnumerable<ReadGeneralSettingDto> data = ObjectMapper.Map<List<ReadGeneralSettingDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<GeneralSettingDto>();
            if (dm.Group != null)
            {
                groupDs = operations.PerformGrouping(data, dm.Group);
            }
            
            var count = data.Count();
            if (dm.Skip != 0)
            {
                data = operations.PerformSkip(data, dm.Skip);
            }
            
            if (dm.Take != 0)
            {
                data = operations.PerformTake(data, dm.Take);
            }
            
            return new ReadGrudDto() { result = data,count = 0, groupDs = groupDs };
        }
        public async Task<IList<GeneralSettingDto>> GetAllAsync()
        {
            var list = await _generalSettingDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<GeneralSettingDto>>(list);
        }
        public async Task<GeneralSettingDto> GetByIdAsync(int id)
        {
            var generalSetting = await _generalSettingDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<GeneralSettingDto>(generalSetting);
        }
        public async Task<UpdateGeneralSettingDto> GetForEditAsync(int id)
        {
            var generalSetting = await _generalSettingDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateGeneralSettingDto>(generalSetting);
        }
        public async Task<CreateGeneralSettingDto> CreateAsync(CreateGeneralSettingDto generalSettingDto)
        {
            var generalSetting = ObjectMapper.Map<GeneralSetting>(generalSettingDto);
            var createdGeneralSetting = await _generalSettingDomainService.CreateAsync(generalSetting);
            return ObjectMapper.Map<CreateGeneralSettingDto>(createdGeneralSetting);
        }
        public async Task<UpdateGeneralSettingDto> UpdateAsync(UpdateGeneralSettingDto generalSettingDto)
        {
            var generalSetting = ObjectMapper.Map<GeneralSetting>(generalSettingDto);
            var updatedGeneralSetting = await _generalSettingDomainService.UpdateAsync(generalSetting);
            return ObjectMapper.Map<UpdateGeneralSettingDto>(updatedGeneralSetting);
        }
        public async Task DeleteAsync(int id)
        {
            await _generalSettingDomainService.DeleteAsync(id);
        }
    }
}

