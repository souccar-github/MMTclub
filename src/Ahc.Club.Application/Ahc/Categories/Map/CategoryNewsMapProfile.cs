using Ahc.Club.Ahc.Categories.Dto;
using AutoMapper;

namespace Ahc.Club.Ahc.Categories.Map
{
    public class CategoryNewsMapProfile : Profile
    {
        public CategoryNewsMapProfile()
        {
            CreateMap<CategoryNews, CategoryNewsDto>();
            CreateMap<CategoryNews, ReadCategoryNewsDto>();
            CreateMap<CreateCategoryNewsDto, CategoryNews>();
            CreateMap<CategoryNews, CreateCategoryNewsDto>();
            CreateMap<UpdateCategoryNewsDto, CategoryNews>();
            CreateMap<CategoryNews, UpdateCategoryNewsDto>();
        }
    }
}
