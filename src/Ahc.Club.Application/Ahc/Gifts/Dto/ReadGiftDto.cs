using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Gifts.Dto
{
   public class ReadGiftDto : EntityDto<int>
    {
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int? levelId { get; set; }
    }
}

