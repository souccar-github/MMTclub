using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Categories.Dto
{
   public class ReadCategoryNewsDto : EntityDto<int>
    {
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        
    }
}

