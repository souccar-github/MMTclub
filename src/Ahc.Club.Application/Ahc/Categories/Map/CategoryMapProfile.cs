using AutoMapper;
using Ahc.Club.Ahc.Categories.Dto;

namespace Ahc.Club.Ahc.Categories.Map
{
   public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryForDropdownDto>();
            CreateMap<Category, ReadCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();
        }
    }
}

