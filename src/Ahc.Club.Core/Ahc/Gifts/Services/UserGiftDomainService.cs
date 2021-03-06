using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Ahc.Club.Ahc.Gifts.Services
{
    public class UserGiftDomainService : IUserGiftDomainService
    {
        private readonly IRepository<UserGift, int> _userGiftRepository;
        public UserGiftDomainService(IRepository<UserGift, int> userGiftRepository)
        {
            _userGiftRepository = userGiftRepository;
        }
        public IQueryable<UserGift> Get()
        {
            return _userGiftRepository.GetAll();
        }
        public async Task<IList<UserGift>> GetAllAsync()
        {
            return await _userGiftRepository.GetAllListAsync();
        }
        public async Task<UserGift> GetByIdAsync(int id)
        {
            return await _userGiftRepository.FirstOrDefaultAsync(id);
        }
        public async Task<UserGift> CreateAsync(UserGift userGift)
        {
            return await _userGiftRepository.InsertAsync(userGift);
        }
        public async Task<UserGift> UpdateAsync(UserGift userGift)
        {
            return await _userGiftRepository.InsertOrUpdateAsync(userGift);
        }
        public async Task DeleteAsync(int id)
        {
            var userGift = await _userGiftRepository.FirstOrDefaultAsync(id);
            await _userGiftRepository.DeleteAsync(userGift);
        }
    }
}

