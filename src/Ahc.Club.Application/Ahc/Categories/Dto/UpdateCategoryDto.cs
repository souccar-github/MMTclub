using System;
using Abp.Application.Services.Dto;
using Ahc.Club.Shared.Dto;

namespace Ahc.Club.Ahc.Categories.Dto
{
   public class UpdateCategoryDto : EntityDto<int>
    {
        //public UpdateCategoryDto(
        //   string name,
        //   string description,
        //   double point,
        //   int? parentCategoryId,
        //   string imagePath)
        //{
        //    Name = name;
        //    Description = description;
        //    Point = point;
        //    ParentCategoryId = parentCategoryId;
        //    ImagePath = imagePath;
        //}

        public string Name { get; set; }
        public string Description { get; set; }
        public FileUploadDto Image { get; set; }
        public double Point { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}

