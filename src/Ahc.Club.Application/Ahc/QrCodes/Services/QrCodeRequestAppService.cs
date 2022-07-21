using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahc.Club.Ahc.QrCodes.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Ahc.Club.Ahc.QrCodes.Services
{
    public class QrCodeRequestAppService : ExchangeAppServiceBase, IQrCodeRequestAppService
    {
        private readonly IQrCodeRequestDomainService _qrCodeRequestDomainService;
        public QrCodeRequestAppService(IQrCodeRequestDomainService qrCodeRequestDomainService)
        {
            _qrCodeRequestDomainService = qrCodeRequestDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _qrCodeRequestDomainService.Get().ToList();
            IEnumerable<ReadQrCodeRequestDto> data = ObjectMapper.Map<List<ReadQrCodeRequestDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<QrCodeRequestDto>();
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
        public async Task<IList<QrCodeRequestDto>> GetAllAsync()
        {
            var list = await _qrCodeRequestDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<QrCodeRequestDto>>(list);
        }
        public async Task<QrCodeRequestDto> GetByIdAsync(int id)
        {
            var qrCodeRequest = await _qrCodeRequestDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<QrCodeRequestDto>(qrCodeRequest);
        }
        public async Task<UpdateQrCodeRequestDto> GetForEditAsync(int id)
        {
            var qrCodeRequest = await _qrCodeRequestDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateQrCodeRequestDto>(qrCodeRequest);
        }
        public async Task<CreateQrCodeRequestDto> CreateAsync(CreateQrCodeRequestDto qrCodeRequestDto)
        {
            var qrCodeRequest = ObjectMapper.Map<QrCodeRequest>(qrCodeRequestDto);
            var createdQrCodeRequest = await _qrCodeRequestDomainService.CreateAsync(qrCodeRequest);
            return ObjectMapper.Map<CreateQrCodeRequestDto>(createdQrCodeRequest);
        }
        public async Task<UpdateQrCodeRequestDto> UpdateAsync(UpdateQrCodeRequestDto qrCodeRequestDto)
        {
            var qrCodeRequest = ObjectMapper.Map<QrCodeRequest>(qrCodeRequestDto);
            var updatedQrCodeRequest = await _qrCodeRequestDomainService.UpdateAsync(qrCodeRequest);
            return ObjectMapper.Map<UpdateQrCodeRequestDto>(updatedQrCodeRequest);
        }
        public async Task DeleteAsync(int id)
        {
            await _qrCodeRequestDomainService.DeleteAsync(id);
        }
    }
}

