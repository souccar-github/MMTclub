using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Indexes.Dto
{
   public class UpdateGiftNameDto : EntityDto<int>
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
