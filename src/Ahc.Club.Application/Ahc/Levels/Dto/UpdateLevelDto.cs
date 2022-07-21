using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Levels.Dto
{
   public class UpdateLevelDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Point { get; set; }
        public string Color { get; set; }
    }
}

