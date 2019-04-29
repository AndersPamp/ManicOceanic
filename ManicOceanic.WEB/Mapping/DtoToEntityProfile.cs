using AutoMapper;
using ManicOceanic.DOMAIN;
using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.WEB.Dto;

namespace ManicOceanic.WEB.Mapping
{
    public class DtoToEntityProfile:Profile
  {
    public DtoToEntityProfile()
    {
      CreateMap<CategoryDto, Category>();
      CreateMap<CustomerDto, Customer>();
      CreateMap<OrderDto, Order>();
      CreateMap<ProductDto, Product>();
    }
  }
}
