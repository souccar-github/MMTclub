using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Categories.Dto
{
   public class ReadCategoryNewsDto : EntityDto<int>
    {
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public double point { get; set; }
        public int? parentCategoryNewsId { get; set; }
        public ReadCategoryNewsDto parentCategoryNews { get; set; }
    }
}

