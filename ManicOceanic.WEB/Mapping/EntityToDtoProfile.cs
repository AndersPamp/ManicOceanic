using AutoMapper;
using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.WEB.Dto;
using ManicOceanic.WEB.Extensions;

namespace ManicOceanic.WEB.Mapping
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
