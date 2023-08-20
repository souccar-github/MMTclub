using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahc.Club.Ahc.Notifications.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;
using Ahc.Club.Ahc.Products;

namespace Ahc.Club.Ahc.Notifications.Services
{
    public class FcmNotificationAppService : ExchangeAppServiceBase, IFcmNotificationAppService
    {
        private readonly IFcmNotificationDomainService _fcmNotificationDomainService;
        public FcmNotificationAppService(IFcmNotificationDomainService fcmNotificationDomainService)
        {
            _fcmNotificationDomainService = fcmNotificationDomainService;
        }
        [HttpPost]
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _fcmNotificationDomainService.Get().ToList();
            IEnumerable<ReadFcmNotificationDto> data = ObjectMapper.Map<List<ReadFcmNotificationDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<FcmNotificationDto>();
            if (dm.Group != null)
            {
                groupDs = operations.PerformGrouping(data, dm.Group);
            }
            
            var count = data.Count();
            if (dm.Skip != 0)
            {
                data = operations.PerformSkip(data, dm.Skip);
            }
            
            if (dm.Take != 0)
            {
                data = operations.PerformTake(data, dm.Take);
            }
            
            return new ReadGrudDto() { result = data,count = 0, groupDs = groupDs };
        }
        public async Task<IList<FcmNotificationDto>> GetAllAsync()
        {
            var list = await _fcmNotificationDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<FcmNotificationDto>>(list);
        }
        public async Task<IList<FcmNotificationDto>> GetMobileAllAsync(long id, int skip, int take)
        {
            var list = await _fcmNotificationDomainService.GetAllAsync();
            list = list.Skip(skip * take).Take(take).ToList();
            return ObjectMapper.Map<IList<FcmNotificationDto>>(list.Where(x=>x.UserId == id));
        }
        public async Task<FcmNotificationDto> GetByIdAsync(int id)
        {
            var fcmNotification = await _fcmNotificationDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<FcmNotificationDto>(fcmNotification);
        }
        public async Task<UpdateFcmNotificationDto> GetForEditAsync(int id)
        {
            var fcmNotification = await _fcmNotificationDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UpdateFcmNotificationDto>(fcmNotification);
        }
        public async Task<CreateFcmNotificationDto> CreateAsync(CreateFcmNotificationDto fcmNotificationDto)
        {
            var fcmNotification = ObjectMapper.Map<FcmNotification>(fcmNotificationDto);
            var createdFcmNotification = await _fcmNotificationDomainService.CreateAsync(fcmNotification);
            return ObjectMapper.Map<CreateFcmNotificationDto>(createdFcmNotification);
        }
        public async Task<UpdateFcmNotificationDto> UpdateAsync(UpdateFcmNotificationDto fcmNotificationDto)
        {
            var fcmNotification = ObjectMapper.Map<FcmNotification>(fcmNotificationDto);
            var updatedFcmNotification = await _fcmNotificationDomainService.UpdateAsync(fcmNotification);
            return ObjectMapper.Map<UpdateFcmNotificationDto>(updatedFcmNotification);
        }
        public async Task DeleteAsync(int id)
        {
            await _fcmNotificationDomainService.DeleteAsync(id);
        }
        public async Task Read(int id)
        {
            var notification =  await _fcmNotificationDomainService.GetByIdAsync(id);
            notification.IsRead = true;
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}

