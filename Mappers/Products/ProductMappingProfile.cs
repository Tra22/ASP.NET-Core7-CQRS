using AutoMapper;
using CQRS.Entities;
using CQRS.Payloads.Requests.Products;
using CQRS.Payloads.Responses.Products;

namespace CQRS.Mappers.Products
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
        }
    }
}
