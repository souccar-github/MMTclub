using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Ahc.Club.Ahc.QrCodes.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Ahc.Club.Ahc.QrCodes.Services
{
    public interface IQrCodeAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<QrCodeDto>> GetAllAsync();
        Task<IList<QrCodeDto>> GetAllByRequestIdAsync(int requestId);
        Task<QrCodeDto> GetByIdAsync(int id);
        Task<UpdateQrCodeDto> GetForEditAsync(int id);
        Task<CreateQrCodeDto> CreateAsync(CreateQrCodeDto qrCode);
        Task<UpdateQrCodeDto> UpdateAsync(UpdateQrCodeDto qrCode);
        Task DeleteAsync(int id);
        Task<QrCodeDto> ReadCode(string code);
    }
}

