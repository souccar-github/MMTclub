using System;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Http;

namespace Ahc.Club.Ahc.Categories.Dto
{
   public class CreateCategoryNewsDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public int? ParentCategoryNewsId { get; set; }
        public string Image { get; set; }
    }
}

