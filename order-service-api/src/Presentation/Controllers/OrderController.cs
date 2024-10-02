using Microsoft.AspNetCore.Mvc;
using OrderServiceAPI.src.Aplication.Services.Interfaces;
using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Presentation.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Order cannot be null");

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

        [HttpPut("{id}/status")]
        public async Task<IActionResult> SetOrderStatus(Guid id, [FromBody] OrderStatus status)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
                return NotFound("Order not found");

            await _orderService.SetOrderStatusAsync(id, status);
            return NoContent();
        }

        [HttpPut("{id}/addItem")]
        public async Task<IActionResult> AddItemToOrder(Guid id, [FromBody] OrderItem item)
        {
            if (item == null)
                return BadRequest("Order item cannot be null");

            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
                return NotFound("Order not found");

            await _orderService.AddItemToOrderAsync(id, item);
            return NoContent();
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
