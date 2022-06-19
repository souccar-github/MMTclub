using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Ahc.Club.Ahc.Categories.Dto;

namespace Ahc.Club.Ahc.Products.Dto
{
   public class ReadProductDto : EntityDto<int>
    {
        public ReadProductDto()
        {
            productSizes = new List<ReadProductSizeDto>();
            productImages = new List<ReadProductImageDto>();
        }
        
        public string name { get; set; }
        public string description { get; set; }
        public double point { get; set; }
        public int? categoryId { get; set; }
        public ReadCategoryDto category { get; set; }
        public IList<ReadProductSizeDto> productSizes { get; set; }
        public IList<ReadProductImageDto> productImages { get; set; }
    }
}

