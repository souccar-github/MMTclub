using System;
using Abp.Application.Services.Dto;
using Ahc.Club.Shared.Dto;
using Microsoft.AspNetCore.Http;

namespace Ahc.Club.Ahc.Categories.Dto
{
   public class CreateCategoryDto : EntityDto<int>
    {
        //public CreateCategoryDto(
        //    string name, 
        //    string description, 
        //    double point, 
        //    int? parentCategoryId
        //    )
        //{
        //    Name = name;
        //    Description = description;
        //    Point = point;
        //    ParentCategoryId = parentCategoryId;
            
        //}

        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public int? ParentCategoryId { get; set; }
        public FileUploadDto Image { get; set; }
    }
}

