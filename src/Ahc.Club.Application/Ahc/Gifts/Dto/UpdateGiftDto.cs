using System;
using Abp.Application.Services.Dto;
using Ahc.Club.Shared.Dto;

namespace Ahc.Club.Ahc.Gifts.Dto
{
   public class UpdateGiftDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public FileUploadDto Image { get; set; }
        public int? LevelId { get; set; }
    }
}

