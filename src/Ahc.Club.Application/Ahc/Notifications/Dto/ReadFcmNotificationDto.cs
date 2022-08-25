using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Notifications.Dto
{
   public class ReadFcmNotificationDto : EntityDto<int>
    {
        public string title { get; set; }
        public string body { get; set; }
        public int distType { get; set; }
        public int? distId { get; set; }
        public bool isRead { get; set; }
    }
}

