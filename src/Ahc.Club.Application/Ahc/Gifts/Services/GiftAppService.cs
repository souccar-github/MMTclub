using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahc.Club.Ahc.Gifts.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Ahc.Club.Ahc.Gifts.Services
{
    public class GiftAppService : ExchangeAppServiceBase, IGiftAppService
    {
        private readonly IGiftDomainService _giftDomainService;
        public GiftAppService(IGiftDomainService giftDomainService)
        {
            _giftDomainService = giftDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _giftDomainService.Get().ToList();
            IEnumerable<ReadGiftDto> data = ObjectMapper.Map<List<ReadGiftDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<GiftDto>();
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
        public async Task<IList<GiftDto>> GetAllAsync()
        {
            var list = await _giftDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<GiftDto>>(list);
        }
        public async Task<GiftDto> GetByIdAsync(int id)
        {
            var gift = await _giftDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<GiftDto>(gift);
        }
        public async Task<UpdateGiftDto> GetForEditAsync(int id)
        {
            var gift = await _giftDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateGiftDto>(gift);
        }
        public async Task<CreateGiftDto> CreateAsync(CreateGiftDto giftDto)
        {
            var gift = ObjectMapper.Map<Gift>(giftDto);
            var createdGift = await _giftDomainService.CreateAsync(gift);
            return ObjectMapper.Map<CreateGiftDto>(createdGift);
        }
        public async Task<UpdateGiftDto> UpdateAsync(UpdateGiftDto giftDto)
        {
            var gift = ObjectMapper.Map<Gift>(giftDto);
            var updatedGift = await _giftDomainService.UpdateAsync(gift);
            return ObjectMapper.Map<UpdateGiftDto>(updatedGift);
        }
        public async Task DeleteAsync(int id)
        {
            await _giftDomainService.DeleteAsync(id);
        }
    }
}

