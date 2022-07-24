using AutoMapper;
using Ahc.Club.Ahc.Categories.Dto;

namespace Ahc.Club.Ahc.Categories.Map
{
   public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, ParentCategoryDto>();
            CreateMap<Category, CategoryForDropdownDto>();
            CreateMap<Category, ReadCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CreateCategoryDto>().ForMember(m => m.Image, a => a.Ignore());
            CreateMap<UpdateCategoryDto, Category>().ForMember(m => m.Image, a => a.Ignore());
            CreateMap<Category, UpdateCategoryDto>().ForMember(m => m.Image, a => a.Ignore());
        }
    }
}

