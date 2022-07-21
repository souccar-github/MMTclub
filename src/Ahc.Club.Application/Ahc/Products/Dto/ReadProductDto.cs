using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Ahc.Club.Ahc.Categories.Dto;

namespace Ahc.Club.Ahc.Products.Dto
{
   public class ReadProductDto : EntityDto<int>
    {
        
        public string name { get; set; }
        public string description { get; set; }
        public double point { get; set; }
        public int? categoryId { get; set; }
        public string firstImage { get; set; }
        public string secondImage { get; set; }
        public string thirdImage { get; set; }
        public ReadCategoryDto category { get; set; }
       
    }
}

