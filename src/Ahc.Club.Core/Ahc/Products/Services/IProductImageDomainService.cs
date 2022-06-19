using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.Products.Services
{
    public interface IProductImageDomainService : IDomainService
     {
        IQueryable<ProductImage> Get();
        Task<IList<ProductImage>> GetAllAsync();
        Task<ProductImage> GetByIdAsync(int id);
        Task<ProductImage> CreateAsync(ProductImage productImage);
        Task<ProductImage> UpdateAsync(ProductImage productImage);
        Task DeleteAsync(int id);
    }
}

