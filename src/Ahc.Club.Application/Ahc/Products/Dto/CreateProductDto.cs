using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Ahc.Club.Shared.Dto;

namespace Ahc.Club.Ahc.Products.Dto
{
   public class CreateProductDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public FileUploadDto FirstImage { get; set; }
        public FileUploadDto SecondImage { get; set; }
        public FileUploadDto ThirdImage { get; set; }
        public int? CategoryId { get; set; }
        
    }
}

