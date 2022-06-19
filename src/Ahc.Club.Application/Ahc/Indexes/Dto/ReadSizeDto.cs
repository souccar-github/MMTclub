using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Indexes.Dto
{
   public class ReadSizeDto : EntityDto<int>
    {
        public string name { get; set; }
        public int order { get; set; }
    }
}

