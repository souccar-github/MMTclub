using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.Indexes.Services
{
    public interface ISizeDomainService : IDomainService
     {
        IQueryable<Size> Get();
        Task<IList<Size>> GetAllAsync();
        Task<Size> GetByIdAsync(int id);
        Task<Size> CreateAsync(Size size);
        Task<Size> UpdateAsync(Size size);
        Task DeleteAsync(int id);
    }
}

