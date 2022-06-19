using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahc.Club.Ahc.Categories.Dto
{
    public class CategoryForDropdownDto : EntityDto
    {
        public string Name { get; set; }
        public CategoryForDropdownDto ParentCategory { get; set; }
        public string FullName { 
            get 
            {
                if(ParentCategory != null)
                    return $"{ParentCategory.FullName} > {Name}";
                else
                    return Name;
            }
        }

    }
}
