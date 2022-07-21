using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Ahc.Club.Ahc.Indexes.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Ahc.Club.Ahc.Indexes.Services
{
    public interface IGiftNameAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<GiftNameDto>> GetAllAsync();
        Task<GiftNameDto> GetByIdAsync(int id);
        Task<UpdateGiftNameDto> GetForEditAsync(int id);
        Task<CreateGiftNameDto> CreateAsync(CreateGiftNameDto giftName);
        Task<UpdateGiftNameDto> UpdateAsync(UpdateGiftNameDto giftName);
        Task DeleteAsync(int id);
    }
}

