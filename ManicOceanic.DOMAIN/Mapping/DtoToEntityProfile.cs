using AutoMapper;
using ManicOceanic.DOMAIN.Dto;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.DOMAIN.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
