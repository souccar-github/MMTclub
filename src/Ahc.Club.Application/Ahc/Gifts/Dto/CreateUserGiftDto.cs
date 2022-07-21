using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Gifts.Dto
{
   public class CreateUserGiftDto : EntityDto<int>
    {
        public int? GiftId { get; set; }
        public DateTime? Date { get; set; }
    }
}

