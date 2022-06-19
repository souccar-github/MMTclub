using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Ahc.Club.Ahc.Products.Services
{
    public class ProductImageDomainService : IProductImageDomainService
    {
        private readonly IRepository<ProductImage, int> _productImageRepository;
        public ProductImageDomainService(IRepository<ProductImage, int> productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }
        public IQueryable<ProductImage> Get()
        {
            return _productImageRepository.GetAll();
        }
        public async Task<IList<ProductImage>> GetAllAsync()
        {
            return await _productImageRepository.GetAllListAsync();
        }
        public async Task<ProductImage> GetByIdAsync(int id)
        {
            return await _productImageRepository.FirstOrDefaultAsync(id);
        }
        public async Task<ProductImage> CreateAsync(ProductImage productImage)
        {
            return await _productImageRepository.InsertAsync(productImage);
        }
        public async Task<ProductImage> UpdateAsync(ProductImage productImage)
        {
            return await _productImageRepository.InsertOrUpdateAsync(productImage);
        }
        public async Task DeleteAsync(int id)
        {
            var productImage = await _productImageRepository.FirstOrDefaultAsync(id);
            await _productImageRepository.DeleteAsync(productImage);
        }
    }
}

