using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Ahc.Club.Ahc.Indexes.Services
{
    public class GiftNameDomainService : IGiftNameDomainService
    {
        private readonly IRepository<GiftName, int> _giftNameRepository;
        public GiftNameDomainService(IRepository<GiftName, int> giftNameRepository)
        {
            _giftNameRepository = giftNameRepository;
        }
        public IQueryable<GiftName> Get()
        {
            return _giftNameRepository.GetAll();
        }
        public async Task<IList<GiftName>> GetAllAsync()
        {
            return await _giftNameRepository.GetAllListAsync();
        }
        public async Task<GiftName> GetByIdAsync(int id)
        {
            return await _giftNameRepository.FirstOrDefaultAsync(id);
        }
        public async Task<GiftName> CreateAsync(GiftName giftName)
        {
            return await _giftNameRepository.InsertAsync(giftName);
        }
        public async Task<GiftName> UpdateAsync(GiftName giftName)
        {
            return await _giftNameRepository.InsertOrUpdateAsync(giftName);
        }
        public async Task DeleteAsync(int id)
        {
            var giftName = await _giftNameRepository.FirstOrDefaultAsync(id);
            await _giftNameRepository.DeleteAsync(giftName);
        }
    }
}

