using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Ahc.Club.Ahc.Notifications.Services
{
    public class FcmNotificationDomainService : IFcmNotificationDomainService
    {
        private readonly IRepository<FcmNotification, int> _fcmNotificationRepository;
        public FcmNotificationDomainService(IRepository<FcmNotification, int> fcmNotificationRepository)
        {
            _fcmNotificationRepository = fcmNotificationRepository;
        }
        public IQueryable<FcmNotification> Get()
        {
            return _fcmNotificationRepository.GetAll();
        }
        public async Task<IList<FcmNotification>> GetAllAsync()
        {
            return await _fcmNotificationRepository.GetAllListAsync();
        }
        public async Task<FcmNotification> GetByIdAsync(int id)
        {
            return await _fcmNotificationRepository.FirstOrDefaultAsync(id);
        }
        public async Task<FcmNotification> CreateAsync(FcmNotification fcmNotification)
        {
            return await _fcmNotificationRepository.InsertAsync(fcmNotification);
        }
        public async Task<FcmNotification> UpdateAsync(FcmNotification fcmNotification)
        {
            return await _fcmNotificationRepository.InsertOrUpdateAsync(fcmNotification);
        }
        public async Task DeleteAsync(int id)
        {
            var fcmNotification = await _fcmNotificationRepository.FirstOrDefaultAsync(id);
            await _fcmNotificationRepository.DeleteAsync(fcmNotification);
        }
    }
}

