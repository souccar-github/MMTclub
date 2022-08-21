using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Ahc.Club.Ahc.Gifts.Dto;
using Ahc.Club.Shared;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Ahc.Club.Ahc.Gifts.Services
{
    public interface IGiftAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] AhcDataManagerRequest dm);
        IList<GiftDto> GetByLevelId(int giftId);
        Task<IList<GiftDto>> GetAllAsync();
        Task<GiftDto> GetByIdAsync(int id);
        Task<UpdateGiftDto> GetForEditAsync(int id);
        Task<CreateGiftDto> CreateAsync(CreateGiftDto gift);
        Task<UpdateGiftDto> UpdateAsync(UpdateGiftDto gift);
        Task DeleteAsync(int id);
    }
}

