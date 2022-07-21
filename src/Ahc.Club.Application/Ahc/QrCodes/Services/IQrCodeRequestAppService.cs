using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Ahc.Club.Ahc.QrCodes.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Ahc.Club.Ahc.QrCodes.Services
{
    public interface IQrCodeRequestAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<QrCodeRequestDto>> GetAllAsync();
        Task<QrCodeRequestDto> GetByIdAsync(int id);
        Task<UpdateQrCodeRequestDto> GetForEditAsync(int id);
        Task<CreateQrCodeRequestDto> CreateAsync(CreateQrCodeRequestDto qrCodeRequest);
        Task<UpdateQrCodeRequestDto> UpdateAsync(UpdateQrCodeRequestDto qrCodeRequest);
        Task DeleteAsync(int id);
    }
}

