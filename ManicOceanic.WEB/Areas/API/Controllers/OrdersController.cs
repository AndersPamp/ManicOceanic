using System.Threading.Tasks;
using AutoMapper;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.DOMAIN.Services.Interfaces;
using ManicOceanic.WEB.Dto;
using ManicOceanic.WEB.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ManicOceanic.WEB.Areas.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrdersController : ControllerBase
  {
    private readonly IOrderService orderService;
    private readonly IMapper mapper;


    public OrdersController(IOrderService orderService, IMapper mapper)
    {
      this.orderService = orderService;
      this.mapper = mapper;

    }

    [HttpPost]
    public async Task<ActionResult<Order>> AddCategoryAsync([FromBody] OrderDto orderDto)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState.GetErrorMessages());

      var order = mapper.Map<OrderDto, Order>(orderDto);
      var result = await orderService.CreateOrderAsync(order);
      return Created($"/api/orders/{result.Id}", result);
    }


    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Order>> DeleteOrderAsync(int id)
    {
      var result = await orderService.DeleteOrderAsync(id);
      return Ok(result);
    }

    [HttpPut]

    public async Task<ActionResult<Order>> UpdateOrderAsync([FromBody] OrderDto orderDto
    )
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState.GetErrorMessages());
      var order = mapper.Map<OrderDto, Order>(orderDto);

      var result = await orderService.UpdateOrderAsync(order);
      return Accepted($"api/categories/{result.Id}", result);
    }

  }
}