using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Products.Dto
{
   public class UpdateProductDto : EntityDto<int>
    {
        public UpdateProductDto()
        {
            ProductSizes = new List<UpdateProductSizeDto>();
            ProductImages = new List<UpdateProductImageDto>();
        }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public int? CategoryId { get; set; }
        public IList<UpdateProductSizeDto> ProductSizes { get; set; }
        public IList<UpdateProductImageDto> ProductImages { get; set; }
    }
}

