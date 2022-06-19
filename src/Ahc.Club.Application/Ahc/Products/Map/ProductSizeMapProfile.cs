using AutoMapper;
using Ahc.Club.Ahc.Products.Dto;

namespace Ahc.Club.Ahc.Products.Map
{
   public class ProductSizeMapProfile : Profile
    {
        public ProductSizeMapProfile()
        {
            CreateMap<ProductSize, ProductSizeDto>();
            CreateMap<ProductSize, ReadProductSizeDto>();
            CreateMap<CreateProductSizeDto, ProductSize>();
            CreateMap<ProductSize, CreateProductSizeDto>();
            CreateMap<UpdateProductSizeDto, ProductSize>();
            CreateMap<ProductSize, UpdateProductSizeDto>();
        }
    }
}

