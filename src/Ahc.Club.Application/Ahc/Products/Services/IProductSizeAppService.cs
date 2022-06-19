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
    public interface IProductSizeAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<ProductSizeDto>> GetAllAsync();
        Task<ProductSizeDto> GetByIdAsync(int id);
        Task<UpdateProductSizeDto> GetForEditAsync(int id);
        Task<CreateProductSizeDto> CreateAsync(CreateProductSizeDto productSize);
        Task<UpdateProductSizeDto> UpdateAsync(UpdateProductSizeDto productSize);
        Task DeleteAsync(int id);
    }
}

