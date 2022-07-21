using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Gifts.Dto
{
   public class UserGiftDto : EntityDto<int>
    {
        public int? GiftId { get; set; }
        public DateTime? Date { get; set; }
    }
}

