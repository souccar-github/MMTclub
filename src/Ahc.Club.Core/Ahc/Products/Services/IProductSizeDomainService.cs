using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.Products.Services
{
    public interface IProductSizeDomainService : IDomainService
     {
        IQueryable<ProductSize> Get();
        Task<IList<ProductSize>> GetAllAsync();
        Task<ProductSize> GetByIdAsync(int id);
        Task<ProductSize> CreateAsync(ProductSize productSize);
        Task<ProductSize> UpdateAsync(ProductSize productSize);
        Task DeleteAsync(int id);
    }
}

