using AutoMapper;
using ManicOceanic.DOMAIN.Dto;
using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.DOMAIN.Extensions;

namespace ManicOceanic.DOMAIN.Mapping
{
    public class EntityToDtoProfile : Profile
  {
    public EntityToDtoProfile()
    {
      CreateMap<Category, CategoryDto>();
      CreateMap<Customer, CustomerDto>();
      CreateMap<Order, OrderDto>();
      CreateMap<Product, ProductDto>().ForMember(src => src.UnitOfMeasure,
        opt => opt.MapFrom(src => src.UnitOfMeasure.ToDescriptionString()));
    }
  }
}
