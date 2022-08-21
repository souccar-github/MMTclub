using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Categories.Dto
{
   public class CategoryNewsDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        
    }
}

