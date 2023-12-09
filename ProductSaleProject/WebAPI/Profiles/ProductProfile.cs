using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
