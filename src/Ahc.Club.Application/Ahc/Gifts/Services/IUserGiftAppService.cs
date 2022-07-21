using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Ahc.Club.Ahc.Gifts.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Ahc.Club.Ahc.Gifts.Services
{
    public interface IUserGiftAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<UserGiftDto>> GetAllAsync();
        Task<UserGiftDto> GetByIdAsync(int id);
        Task<UpdateUserGiftDto> GetForEditAsync(int id);
        Task<CreateUserGiftDto> CreateAsync(CreateUserGiftDto userGift);
        Task<UpdateUserGiftDto> UpdateAsync(UpdateUserGiftDto userGift);
        Task DeleteAsync(int id);
    }
}

