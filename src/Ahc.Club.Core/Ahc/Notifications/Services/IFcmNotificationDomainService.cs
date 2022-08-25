using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Ahc.Club.Ahc.Notifications.Services
{
    public interface IFcmNotificationDomainService : IDomainService
     {
        IQueryable<FcmNotification> Get();
        Task<IList<FcmNotification>> GetAllAsync();
        Task<FcmNotification> GetByIdAsync(int id);
        Task<FcmNotification> CreateAsync(FcmNotification fcmNotification);
        Task<FcmNotification> UpdateAsync(FcmNotification fcmNotification);
        Task DeleteAsync(int id);
    }
}

