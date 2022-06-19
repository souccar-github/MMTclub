using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Ahc.Club.Ahc.Products.Services
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IRepository<Product, int> _productRepository;
        public ProductDomainService(IRepository<Product, int> productRepository)
        {
            _productRepository = productRepository;
        }
        public IQueryable<Product> Get()
        {
            return _productRepository.GetAllIncluding(c => c.Category);
        }
        public async Task<IList<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllListAsync();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Product> CreateAsync(Product product)
        {
            return await _productRepository.InsertAsync(product);
        }
        public async Task<Product> UpdateAsync(Product product)
        {
            return await _productRepository.InsertOrUpdateAsync(product);
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _productRepository.FirstOrDefaultAsync(id);
            await _productRepository.DeleteAsync(product);
        }
    }
}

