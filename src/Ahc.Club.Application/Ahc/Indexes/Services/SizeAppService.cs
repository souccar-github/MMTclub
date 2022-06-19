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
    public class SizeAppService : ExchangeAppServiceBase, ISizeAppService
    {
        private readonly ISizeDomainService _sizeDomainService;
        public SizeAppService(ISizeDomainService sizeDomainService)
        {
            _sizeDomainService = sizeDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _sizeDomainService.Get().ToList();
            IEnumerable<ReadSizeDto> data = ObjectMapper.Map<List<ReadSizeDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<SizeDto>();
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
        public async Task<IList<SizeDto>> GetAllAsync()
        {
            var list = await _sizeDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<SizeDto>>(list);
        }
        public async Task<SizeDto> GetByIdAsync(int id)
        {
            var size = await _sizeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<SizeDto>(size);
        }
        public async Task<UpdateSizeDto> GetForEditAsync(int id)
        {
            var size = await _sizeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateSizeDto>(size);
        }
        public async Task<CreateSizeDto> CreateAsync(CreateSizeDto sizeDto)
        {
            var size = ObjectMapper.Map<Size>(sizeDto);
            var createdSize = await _sizeDomainService.CreateAsync(size);
            return ObjectMapper.Map<CreateSizeDto>(createdSize);
        }
        public async Task<UpdateSizeDto> UpdateAsync(UpdateSizeDto sizeDto)
        {
            var size = ObjectMapper.Map<Size>(sizeDto);
            var updatedSize = await _sizeDomainService.UpdateAsync(size);
            return ObjectMapper.Map<UpdateSizeDto>(updatedSize);
        }
        public async Task DeleteAsync(int id)
        {
            await _sizeDomainService.DeleteAsync(id);
        }
    }
}

