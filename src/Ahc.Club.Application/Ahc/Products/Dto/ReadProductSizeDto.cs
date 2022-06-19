using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Products.Dto
{
   public class ReadProductSizeDto : EntityDto<int>
    {
        public double point { get; set; }
        public int? productId { get; set; }
        public int? sizeId { get; set; }
    }
}

