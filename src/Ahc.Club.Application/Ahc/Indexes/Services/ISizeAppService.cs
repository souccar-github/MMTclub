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
    public interface ISizeAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<SizeDto>> GetAllAsync();
        Task<SizeDto> GetByIdAsync(int id);
        Task<UpdateSizeDto> GetForEditAsync(int id);
        Task<CreateSizeDto> CreateAsync(CreateSizeDto size);
        Task<UpdateSizeDto> UpdateAsync(UpdateSizeDto size);
        Task DeleteAsync(int id);
    }
}

