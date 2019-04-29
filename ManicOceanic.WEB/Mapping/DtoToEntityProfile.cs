using AutoMapper;
using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.WEB.Dto;
using ManicOceanic.WEB.Extensions;

namespace ManicOceanic.WEB.Mapping
{
    public class DtoToEntityProfile:Profile
  {
    public DtoToEntityProfile()
    {
      CreateMap<CategoryDto, Category>();
      CreateMap<CustomerDto, Customer>();
      CreateMap<OrderDto, Order>();
      CreateMap<Product, ProductDto>().ForMember(src => src.UnitOfMeasure,
          opt => opt.MapFrom(src => src.UnitOfMeasure.ToDescriptionString()));
        }
  }
}
