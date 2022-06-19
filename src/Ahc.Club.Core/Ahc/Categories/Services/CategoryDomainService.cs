using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Ahc.Club.Ahc.Categories.Services
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private readonly IRepository<Category, int> _categoryRepository;
        public CategoryDomainService(IRepository<Category, int> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IQueryable<Category> Get()
        {
            return _categoryRepository.GetAllIncluding(p=>p.ParentCategory);
        }
        public async Task<IList<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllListAsync();
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Category> CreateAsync(Category category)
        {
            return await _categoryRepository.InsertAsync(category);
        }
        public async Task<Category> UpdateAsync(Category category)
        {
            return await _categoryRepository.InsertOrUpdateAsync(category);
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(id);
            await _categoryRepository.DeleteAsync(category);
        }
    }
}

