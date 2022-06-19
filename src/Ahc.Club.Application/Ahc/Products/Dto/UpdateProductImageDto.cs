using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Products.Dto
{
   public class UpdateProductImageDto : EntityDto<int>
    {
        public string Path { get; set; }
        public string Tag { get; set; }
        public bool IsPrimary { get; set; }
        public int? ProductId { get; set; }
    }
}

