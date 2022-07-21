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
    public class UserGiftAppService : ExchangeAppServiceBase, IUserGiftAppService
    {
        private readonly IUserGiftDomainService _userGiftDomainService;
        public UserGiftAppService(IUserGiftDomainService userGiftDomainService)
        {
            _userGiftDomainService = userGiftDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _userGiftDomainService.Get().ToList();
            IEnumerable<ReadUserGiftDto> data = ObjectMapper.Map<List<ReadUserGiftDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<UserGiftDto>();
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
        public async Task<IList<UserGiftDto>> GetAllAsync()
        {
            var list = await _userGiftDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<UserGiftDto>>(list);
        }
        public async Task<UserGiftDto> GetByIdAsync(int id)
        {
            var userGift = await _userGiftDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UserGiftDto>(userGift);
        }
        public async Task<UpdateUserGiftDto> GetForEditAsync(int id)
        {
            var userGift = await _userGiftDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateUserGiftDto>(userGift);
        }
        public async Task<CreateUserGiftDto> CreateAsync(CreateUserGiftDto userGiftDto)
        {
            var userGift = ObjectMapper.Map<UserGift>(userGiftDto);
            var createdUserGift = await _userGiftDomainService.CreateAsync(userGift);
            return ObjectMapper.Map<CreateUserGiftDto>(createdUserGift);
        }
        public async Task<UpdateUserGiftDto> UpdateAsync(UpdateUserGiftDto userGiftDto)
        {
            var userGift = ObjectMapper.Map<UserGift>(userGiftDto);
            var updatedUserGift = await _userGiftDomainService.UpdateAsync(userGift);
            return ObjectMapper.Map<UpdateUserGiftDto>(updatedUserGift);
        }
        public async Task DeleteAsync(int id)
        {
            await _userGiftDomainService.DeleteAsync(id);
        }
    }
}

