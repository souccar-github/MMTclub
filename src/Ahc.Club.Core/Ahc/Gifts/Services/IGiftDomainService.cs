using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.Gifts.Services
{
    public interface IGiftDomainService : IDomainService
     {
        IQueryable<Gift> Get();
        IQueryable<Gift> GetByLevelId(int levelid);
        Task<IList<Gift>> GetAllAsync();
        Task<Gift> GetByIdAsync(int id);
        Task<Gift> CreateAsync(Gift gift);
        Task<Gift> UpdateAsync(Gift gift);
        Task DeleteAsync(int id);
        
    }
}

