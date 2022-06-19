using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Ahc.Club.Ahc.Products.Services
{
    public class ProductSizeDomainService : IProductSizeDomainService
    {
        private readonly IRepository<ProductSize, int> _productSizeRepository;
        public ProductSizeDomainService(IRepository<ProductSize, int> productSizeRepository)
        {
            _productSizeRepository = productSizeRepository;
        }
        public IQueryable<ProductSize> Get()
        {
            return _productSizeRepository.GetAll();
        }
        public async Task<IList<ProductSize>> GetAllAsync()
        {
            return await _productSizeRepository.GetAllListAsync();
        }
        public async Task<ProductSize> GetByIdAsync(int id)
        {
            return await _productSizeRepository.FirstOrDefaultAsync(id);
        }
        public async Task<ProductSize> CreateAsync(ProductSize productSize)
        {
            return await _productSizeRepository.InsertAsync(productSize);
        }
        public async Task<ProductSize> UpdateAsync(ProductSize productSize)
        {
            return await _productSizeRepository.InsertOrUpdateAsync(productSize);
        }
        public async Task DeleteAsync(int id)
        {
            var productSize = await _productSizeRepository.FirstOrDefaultAsync(id);
            await _productSizeRepository.DeleteAsync(productSize);
        }
    }
}

