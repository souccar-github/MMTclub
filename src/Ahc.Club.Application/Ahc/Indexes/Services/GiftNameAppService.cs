using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahc.Club.Ahc.Indexes.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Ahc.Club.Ahc.Indexes.Services
{
    public class GiftNameAppService : ExchangeAppServiceBase, IGiftNameAppService
    {
        private readonly IGiftNameDomainService _giftNameDomainService;
        public GiftNameAppService(IGiftNameDomainService giftNameDomainService)
        {
            _giftNameDomainService = giftNameDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _giftNameDomainService.Get().ToList();
            IEnumerable<ReadGiftNameDto> data = ObjectMapper.Map<List<ReadGiftNameDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<GiftNameDto>();
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
        public async Task<IList<GiftNameDto>> GetAllAsync()
        {
            var list = await _giftNameDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<GiftNameDto>>(list);
        }
        public async Task<GiftNameDto> GetByIdAsync(int id)
        {
            var giftName = await _giftNameDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<GiftNameDto>(giftName);
        }
        public async Task<UpdateGiftNameDto> GetForEditAsync(int id)
        {
            var giftName = await _giftNameDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateGiftNameDto>(giftName);
        }
        public async Task<CreateGiftNameDto> CreateAsync(CreateGiftNameDto giftNameDto)
        {
            var giftName = ObjectMapper.Map<GiftName>(giftNameDto);
            var createdGiftName = await _giftNameDomainService.CreateAsync(giftName);
            return ObjectMapper.Map<CreateGiftNameDto>(createdGiftName);
        }
        public async Task<UpdateGiftNameDto> UpdateAsync(UpdateGiftNameDto giftNameDto)
        {
            var giftName = ObjectMapper.Map<GiftName>(giftNameDto);
            var updatedGiftName = await _giftNameDomainService.UpdateAsync(giftName);
            return ObjectMapper.Map<UpdateGiftNameDto>(updatedGiftName);
        }
        public async Task DeleteAsync(int id)
        {
            await _giftNameDomainService.DeleteAsync(id);
        }
    }
}

