using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.Gifts.Services
{
    public interface IUserGiftDomainService : IDomainService
     {
        IQueryable<UserGift> Get();
        IQueryable<UserGift> GetAllNoneReceived();
        bool CheckRequestAny(long userId, int level);
        Task<IList<UserGift>> GetAllAsync();
        Task<UserGift> GetByIdAsync(int id);
        Task<UserGift> CreateAsync(UserGift userGift);
        Task<UserGift> UpdateAsync(UserGift userGift);
        Task DeleteAsync(int id);
        Task<UserGift> ChangeStatusAsync(int status, int id);
    }
}

