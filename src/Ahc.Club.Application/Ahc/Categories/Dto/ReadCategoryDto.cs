using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Categories.Dto
{
   public class ReadCategoryDto : EntityDto<int>
    {
        public string name { get; set; }
        public string description { get; set; }
        public string imagePath { get; set; }
        public double point { get; set; }
        public int? parentCategoryId { get; set; }
        public ReadCategoryDto parentCategory { get; set; }
    }
}

