using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.Categories.Services
{
    public interface ICategoryNewsDomainService : IDomainService
     {
        IQueryable<CategoryNews> Get();
        IQueryable<CategoryNews> GetByCategoryId(int categoryId);
        IList<CategoryNews> GetByCategoryId(int categoryId, int count);
        Task<IList<CategoryNews>> GetAllAsync();
        Task<CategoryNews> GetByIdAsync(int id);
        Task<CategoryNews> CreateAsync(CategoryNews news);
        Task<CategoryNews> UpdateAsync(CategoryNews news);
        Task DeleteAsync(int id);
    }
}

