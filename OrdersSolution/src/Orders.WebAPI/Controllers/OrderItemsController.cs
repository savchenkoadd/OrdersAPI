using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Core.DTO.OrderItem;
using Orders.Core.ServiceContracts;

namespace Orders.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderItemsController : ControllerBase
	{
		private IOrderItemService _orderItemService;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

		//GET: /api/orderitems/orderId/{orderId}
		[HttpGet("orderId/{orderId}")]
		public async Task<ActionResult<IEnumerable<OrderItemResponse>>> GetOrderItemsByOrderId(Guid? orderId)
		{
			var orderItems = await _orderItemService.GetOrderItemsByOrderId(orderId);

			return orderItems;
		}

		//GET: /api/orderitems/itemId/{id}
		[HttpGet("itemId/{id}")]
		public async Task<ActionResult<OrderItemResponse>> GetOrderItem(Guid? id)
		{
			var orderItem = await _orderItemService.GetOrderItem(id);

			return orderItem;
		}

		//POST: /api/orderitems
		[HttpPost]
		public async Task<IActionResult> CreateOrderItem(
			[Bind(
				nameof(OrderItemAddRequest.OrderId),
				nameof(OrderItemAddRequest.ProductName),
				nameof(OrderItemAddRequest.UnitPrice),
				nameof(OrderItemAddRequest.Quantity)
			)] OrderItemAddRequest? orderItem)
		{
			var createdId = await _orderItemService.CreateOrderItem(orderItem);

			return CreatedAtAction(nameof(GetOrderItem), new { id = createdId }, orderItem);
		}

		//PUT: /api/orderitems/{id}
		[HttpPut("{id}")]
		public async Task<ActionResult<OrderItemResponse>> UpdateOrderItem(Guid? id,
			[Bind(
				nameof(OrderItemUpdateRequest.ProductName),
				nameof(OrderItemUpdateRequest.UnitPrice),
				nameof(OrderItemUpdateRequest.Quantity)
			)] OrderItemUpdateRequest? orderItem)
		{
			var foundId = await _orderItemService.UpdateOrderItem(id, orderItem);

			return await _orderItemService.GetOrderItem(foundId);
		}

		//DELETE: /api/orderitems/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteOrderItem(Guid? id)
		{
			await _orderItemService.DeleteOrderItem(id);

			return NoContent();
		}
	}
}
