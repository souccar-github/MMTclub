using System;
using Abp.Application.Services.Dto;
using Ahc.Club.Users.Dto;

namespace Ahc.Club.Ahc.Gifts.Dto
{
   public class ReadUserGiftDto : EntityDto<int>
    {
        public int? giftId { get; set; }
        public int status { get; set; }
        public long? userId { get; set; }
        public DateTime? date { get; set; }
        public ReadGiftDto gift { get; set; }
        public ReadUserDto user { get; set; }
    }
}

