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
    public interface IProductAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<ProductDto>> GetAllAsync();
        IList<ProductDto> GetProducts(int? categoryId, string keyword, int skip, int take);
        Task<ProductDto> GetByIdAsync(int id);
        Task<UpdateProductDto> GetForEditAsync(int id);
        Task<CreateProductDto> CreateAsync(CreateProductDto product);
        Task<UpdateProductDto> UpdateAsync(UpdateProductDto product);
        Task DeleteAsync(int id);
    }
}

