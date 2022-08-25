using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Notifications.Dto
{
   public class CreateFcmNotificationDto : EntityDto<int>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int DistType { get; set; }
        public int? DistId { get; set; }
        public bool IsRead { get; set; }
    }
}

