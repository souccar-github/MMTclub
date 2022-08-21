using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Localization;

namespace Ahc.Club.Ahc.Gifts.Services
{
    public class GiftDomainService : IGiftDomainService
    {
        private readonly IRepository<Gift, int> _giftRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ILocalizationManager _localizationManager;
        public GiftDomainService(IRepository<Gift, int> giftRepository)
        {
            _giftRepository = giftRepository;
        }
        public IQueryable<Gift> Get()
        {
            return _giftRepository.GetAll();
        }
        public async Task<IList<Gift>> GetAllAsync()
        {
            return await _giftRepository.GetAllListAsync();
        }
        public async Task<Gift> GetByIdAsync(int id)
        {
            return await _giftRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Gift> CreateAsync(Gift gift)
        {
            return await _giftRepository.InsertAsync(gift);
        }
        public async Task<Gift> UpdateAsync(Gift gift)
        {
            return await _giftRepository.InsertOrUpdateAsync(gift);
        }
        public async Task DeleteAsync(int id)
        {
            var gift = await _giftRepository.FirstOrDefaultAsync(id);
            await _giftRepository.DeleteAsync(gift);
        }
        public IQueryable<Gift> GetByLevelId(int levelId)
        {
            return Get().Where(x => x.LevelId == levelId);
        }
    }
}

