using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Gifts.Dto
{
   public class ReadUserGiftDto : EntityDto<int>
    {
        public int? giftId { get; set; }
        public DateTime? date { get; set; }
    }
}

