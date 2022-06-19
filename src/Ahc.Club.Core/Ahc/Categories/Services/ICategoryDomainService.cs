using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.Categories.Services
{
    public interface ICategoryDomainService : IDomainService
     {
        IQueryable<Category> Get();
        Task<IList<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}

