using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.Indexes.Services
{
    public interface IGiftNameDomainService : IDomainService
     {
        IQueryable<GiftName> Get();
        Task<IList<GiftName>> GetAllAsync();
        Task<GiftName> GetByIdAsync(int id);
        Task<GiftName> CreateAsync(GiftName giftName);
        Task<GiftName> UpdateAsync(GiftName giftName);
        Task DeleteAsync(int id);
    }
}

