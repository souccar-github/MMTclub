using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Products.Dto
{
   public class ProductSizeDto : EntityDto<int>
    {
        public double Point { get; set; }
        public int? ProductId { get; set; }
        public int? SizeId { get; set; }
    }
}

