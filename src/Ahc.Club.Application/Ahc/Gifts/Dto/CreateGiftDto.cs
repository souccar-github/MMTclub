using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Gifts.Dto
{
   public class CreateGiftDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? LevelId { get; set; }
    }
}

