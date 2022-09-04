using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Levels.Dto
{
   public class CreateLevelDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FromPoint { get; set; }
        public int ToPoint { get; set; }
        public string Color { get; set; }
        public int Order { get; set; }
    }
}

