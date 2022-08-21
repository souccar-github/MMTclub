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
            CreateMap<CategoryNews, CreateCategoryNewsDto>().ForMember(m => m.Image, a => a.Ignore());
            CreateMap<UpdateCategoryNewsDto, CategoryNews>().ForMember(m => m.Image, a => a.Ignore());
            CreateMap<CategoryNews, UpdateCategoryNewsDto>().ForMember(m => m.Image, a => a.Ignore());
        }
    }
}
