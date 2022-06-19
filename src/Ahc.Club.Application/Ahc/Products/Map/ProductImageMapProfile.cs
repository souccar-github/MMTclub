using AutoMapper;
using Ahc.Club.Ahc.Products.Dto;

namespace Ahc.Club.Ahc.Products.Map
{
   public class ProductImageMapProfile : Profile
    {
        public ProductImageMapProfile()
        {
            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<ProductImage, ReadProductImageDto>();
            CreateMap<CreateProductImageDto, ProductImage>();
            CreateMap<ProductImage, CreateProductImageDto>();
            CreateMap<UpdateProductImageDto, ProductImage>();
            CreateMap<ProductImage, UpdateProductImageDto>();
        }
    }
}

