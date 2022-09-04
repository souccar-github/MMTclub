using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Levels.Dto
{
   public class ReadLevelDto : EntityDto<int>
    {
        public string name { get; set; }
        public string description { get; set; }
        public int fromPoint { get; set; }
        public int toPoint { get; set; }
        public string color { get; set; }
        public int order { get; set; }
    }
}

