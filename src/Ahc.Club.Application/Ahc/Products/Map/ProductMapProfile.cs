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
            CreateMap<Product, CreateProductDto>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, UpdateProductDto>();
        }
    }
}

