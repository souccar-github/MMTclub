using System;
using Abp.Application.Services.Dto;

namespace Ahc.Club.Ahc.Products.Dto
{
   public class ReadProductImageDto : EntityDto<int>
    {
        public string path { get; set; }
        public string tag { get; set; }
        public bool isPrimary { get; set; }
        public int? productId { get; set; }
    }
}

