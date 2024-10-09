using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderServiceAPI.src.Aplication.Services.Interfaces;
using OrderServiceAPI.src.Domain;
using src.Presentation.DTOs.OrderDTOs;

namespace OrderServiceAPI.src.Presentation.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IOrderItemService orderItemService, IMapper mapper)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] CreateOrderDTO orderDTO)
        {
            if (orderDTO == null)
                return BadRequest("Order cannot be null");

            var order = _mapper.Map<Order>(orderDTO);

            await _orderService.AddAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
                return NotFound("Order not found");

            return Ok(order);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserOrders(Guid userId)
        {
            var orders = await _orderService.GetUserOrdersAsync(userId);
            if (orders == null || !orders.Any())
                return NotFound("No orders found for this user");

            return Ok(orders);
        }

        [HttpGet("user/day/{userId}")]
        public async Task<IActionResult> GetUserDayOrders(Guid userId)
        {
            var orders = await _orderService.GetUserDayOrdersAsync(userId);
            if (orders == null || !orders.Any())
                return NotFound("No orders found for this user today");

            return Ok(orders);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] UpdateOrderDTO orderDTO)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
                return NotFound("Order not found");

            order.Status = orderDTO.Status;
            order.TotalAmount = orderDTO.TotalAmount;

            await _orderService.UpdateAsync(order);
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
                return NotFound("Order not found");

            await _orderService.DeleteAsync(id);
            return NoContent();
        }
    }
}
