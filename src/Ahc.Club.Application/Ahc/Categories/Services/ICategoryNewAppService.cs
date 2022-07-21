using Abp.Application.Services;
using Ahc.Club.Ahc.Categories.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ahc.Club.Ahc.Categories.Services
{
    public interface ICategoryNewsAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        IList<CategoryNewsDto> GetByCategoryId(int categoryId);
        Task<IList<CategoryNewsDto>> GetAllAsync();
        Task<CategoryNewsDto> GetByIdAsync(int id);
        Task<UpdateCategoryNewsDto> GetForEditAsync(int id);
        Task<CreateCategoryNewsDto> CreateAsync(CreateCategoryNewsDto news);
        Task<UpdateCategoryNewsDto> UpdateAsync(UpdateCategoryNewsDto news);
        Task DeleteAsync(int id);
    }
}

