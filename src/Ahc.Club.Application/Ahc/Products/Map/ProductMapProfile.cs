using AutoMapper;
using Ahc.Club.Ahc.Products.Dto;

namespace Ahc.Club.Ahc.Products.Map
{
   public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ReadProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, CreateProductDto>()
                .ForMember(m => m.FirstImage, a => a.Ignore())
                .ForMember(m => m.SecondImage, a => a.Ignore())
                .ForMember(m => m.ThirdImage, a => a.Ignore());

            CreateMap<UpdateProductDto, Product>()
                .ForMember(m => m.FirstImage, a => a.Ignore())
                .ForMember(m => m.SecondImage, a => a.Ignore())
                .ForMember(m => m.ThirdImage, a => a.Ignore());

            CreateMap<Product, UpdateProductDto>()
                .ForMember(m => m.FirstImage, a => a.Ignore())
                .ForMember(m => m.SecondImage, a => a.Ignore())
                .ForMember(m => m.ThirdImage, a => a.Ignore());
        }
    }
}

