using AutoMapper;
using ManicOceanic.DOMAIN.Dto;
using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Entities.Sales;

namespace ManicOceanic.DOMAIN.Mapping
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
