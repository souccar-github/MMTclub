using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Products.Dto
{
   public class ProductDto : EntityDto<int>
    {
        public ProductDto()
        {
            ProductSizes = new List<ProductSizeDto>();
            ProductImages = new List<ProductImageDto>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public int? CategoryId { get; set; }
        
        public IList<ProductSizeDto> ProductSizes { get; set; }
        public IList<ProductImageDto> ProductImages { get; set; }
    }
}

