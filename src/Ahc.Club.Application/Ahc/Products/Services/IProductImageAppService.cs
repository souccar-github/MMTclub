using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Ahc.Club.Ahc.Products.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Ahc.Club.Ahc.Products.Services
{
    public interface IProductImageAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<ProductImageDto>> GetAllAsync();
        Task<ProductImageDto> GetByIdAsync(int id);
        Task<UpdateProductImageDto> GetForEditAsync(int id);
        Task<CreateProductImageDto> CreateAsync(CreateProductImageDto productImage);
        Task<UpdateProductImageDto> UpdateAsync(UpdateProductImageDto productImage);
        Task DeleteAsync(int id);
    }
}

