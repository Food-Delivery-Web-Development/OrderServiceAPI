using Microsoft.AspNetCore.Mvc;
using OrderServiceAPI.src.Aplication.Services.Interfaces;
using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderItem([FromBody] OrderItem orderItem)
        {
            if (orderItem == null)
                return BadRequest("Order item cannot be null");

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
        public async Task<IActionResult> UpdateOrderItem(Guid id, [FromBody] OrderItem orderItem)
        {
            if (orderItem == null || id != orderItem.Id)
                return BadRequest("Invalid order item data");

            var existingOrderItem = await _orderItemService.GetByIdAsync(id);
            if (existingOrderItem == null)
                return NotFound("Order item not found");

            await _orderItemService.UpdateAsync(orderItem);
            return NoContent();
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
