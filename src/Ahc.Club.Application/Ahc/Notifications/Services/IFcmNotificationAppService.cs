using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Ahc.Club.Ahc.Notifications.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Ahc.Club.Ahc.Notifications.Services
{
    public interface IFcmNotificationAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<FcmNotificationDto>> GetAllAsync();
        Task<IList<FcmNotificationDto>> GetMobileAllAsync(long id, int skip, int take);
        Task<FcmNotificationDto> GetByIdAsync(int id);
        Task<UpdateFcmNotificationDto> GetForEditAsync(int id);
        Task<CreateFcmNotificationDto> CreateAsync(CreateFcmNotificationDto fcmNotification);
        Task<UpdateFcmNotificationDto> UpdateAsync(UpdateFcmNotificationDto fcmNotification);
        Task DeleteAsync(int id);
        Task Read(int id);
    }
}

