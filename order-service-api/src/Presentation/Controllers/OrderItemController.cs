using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderServiceAPI.src.Aplication.Services.Interfaces;
using OrderServiceAPI.src.Domain;
using src.Presentation.DTOs.OrderItemDTOs;

namespace OrderServiceAPI.src.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderItemService orderItemService, IOrderService orderService, IMapper mapper)
        {
            _orderItemService = orderItemService;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderItem([FromBody] CreateOrderItemDTO orderItemDTO)
        {
            if (orderItemDTO == null)
                return BadRequest("Order item cannot be null");

            var order = await _orderService.GetByIdAsync(orderItemDTO.OrderId);
            if(order == null)
                return NotFound("Order not found");

            var orderItem = _mapper.Map<OrderItem>(orderItemDTO);

            await _orderItemService.AddAsync(orderItem);
            return CreatedAtAction(nameof(GetOrderItemById), new { id = orderItem.Id }, orderItem);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(Guid id)
        {
            var orderItem = await _orderItemService.GetByIdAsync(id);
            if (orderItem == null)
                return NotFound("Order item not found");

            return Ok(orderItem);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetOrderItemsByOrderId(Guid orderId)
        {
            var orderItems = await _orderItemService.GetUserOrderItems(orderId);
            if (orderItems == null)
                return NotFound("No order items found for this order");

            return Ok(orderItems);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(Guid id, [FromBody] UpdateOrderItemDTO orderItemDTO)
        {
            if (orderItemDTO == null)
                return BadRequest("Invalid order item data");

            var existingOrderItem = await _orderItemService.GetByIdAsync(id);
            if (existingOrderItem == null)
                return NotFound("Order item not found");

            existingOrderItem.Quantity = orderItemDTO.Quantity;
            existingOrderItem.UnitPrice = orderItemDTO.UnitPrice;

            await _orderItemService.UpdateAsync(existingOrderItem);
            return Ok(existingOrderItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(Guid id)
        {
            var existingOrderItem = await _orderItemService.GetByIdAsync(id);
            if (existingOrderItem == null)
                return NotFound("Order item not found");

            await _orderItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
