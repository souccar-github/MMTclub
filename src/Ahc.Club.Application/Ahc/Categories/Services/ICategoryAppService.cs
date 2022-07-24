using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Ahc.Club.Ahc.Categories.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Ahc.Club.Ahc.Categories.Services
{
    public interface ICategoryAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<CategoryDto>> GetAllAsync();
        IList<CategoryForDropdownDto> GetAllForDropdown();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<UpdateCategoryDto> GetForEditAsync(int id);
        Task<CreateCategoryDto> CreateAsync(CreateCategoryDto category);
        Task<UpdateCategoryDto> UpdateAsync(UpdateCategoryDto category);
        Task DeleteAsync(int id);
        IList<ParentCategoryDto> GetParent();
    }
}

