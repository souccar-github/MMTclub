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
    public class QrCodeAppService : ExchangeAppServiceBase, IQrCodeAppService
    {
        private readonly IQrCodeDomainService _qrCodeDomainService;
        public QrCodeAppService(IQrCodeDomainService qrCodeDomainService)
        {
            _qrCodeDomainService = qrCodeDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _qrCodeDomainService.Get().ToList();
            IEnumerable<ReadQrCodeDto> data = ObjectMapper.Map<List<ReadQrCodeDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<QrCodeDto>();
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
        public async Task<IList<QrCodeDto>> GetAllAsync()
        {
            var list = await _qrCodeDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<QrCodeDto>>(list);
        }
        public async Task<QrCodeDto> GetByIdAsync(int id)
        {
            var qrCode = await _qrCodeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<QrCodeDto>(qrCode);
        }
        public async Task<UpdateQrCodeDto> GetForEditAsync(int id)
        {
            var qrCode = await _qrCodeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateQrCodeDto>(qrCode);
        }
        public async Task<CreateQrCodeDto> CreateAsync(CreateQrCodeDto qrCodeDto)
        {
            var qrCode = ObjectMapper.Map<QrCode>(qrCodeDto);
            var createdQrCode = await _qrCodeDomainService.CreateAsync(qrCode);
            return ObjectMapper.Map<CreateQrCodeDto>(createdQrCode);
        }
        public async Task<UpdateQrCodeDto> UpdateAsync(UpdateQrCodeDto qrCodeDto)
        {
            var qrCode = ObjectMapper.Map<QrCode>(qrCodeDto);
            var updatedQrCode = await _qrCodeDomainService.UpdateAsync(qrCode);
            return ObjectMapper.Map<UpdateQrCodeDto>(updatedQrCode);
        }
        public async Task DeleteAsync(int id)
        {
            await _qrCodeDomainService.DeleteAsync(id);
        }
    }
}

