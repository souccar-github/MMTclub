using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Products.Dto
{
   public class CreateProductDto : EntityDto<int>
    {
        public CreateProductDto()
        {
            ProductSizes = new List<CreateProductSizeDto>();
            ProductImages = new List<CreateProductImageDto>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public int? CategoryId { get; set; }
        public IList<CreateProductSizeDto> ProductSizes { get; set; }
        public IList<CreateProductImageDto> ProductImages { get; set; }
    }
}

