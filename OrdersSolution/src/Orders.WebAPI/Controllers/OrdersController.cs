﻿using Microsoft.AspNetCore.Mvc;
using Orders.Core.DTO.Order;
using Orders.Core.ServiceContracts;

namespace Orders.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;

        public OrdersController(
                IOrderService orderService
            )
        {
            _orderService = orderService;
        }

        //GET: /api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrders()
        {
            var orders = await _orderService.GetAllOrders();

            return orders;
        }

		//GET: /api/Orders/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<OrderResponse>> GetOrder(Guid? id)
		{
			var order = await _orderService.GetOrder(id);

			return order;
		}

		//POST: /api/Orders
		[HttpPost]
		public async Task<IActionResult> CreateOrder([Bind(nameof(OrderAddRequest.OrderId), nameof(OrderAddRequest.CustomerName))]OrderAddRequest? orderAddRequest)
		{
			var orderId = await _orderService.CreateOrder(orderAddRequest);

			return CreatedAtAction(nameof(GetOrder), new { id = orderId }, orderAddRequest);
		}

		//PUT: /api/Orders/{orderId}
		[HttpPut("{orderId}")]
		public async Task<ActionResult<OrderResponse>> UpdateOrder(Guid? orderId, OrderUpdateRequest? orderUpdateRequest)
		{
			var foundId = await _orderService.UpdateOrder(orderId, orderUpdateRequest);

			return Ok(await _orderService.GetOrder(foundId));
		}

		//DELETE: /api/Orders/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteOrder(Guid? id)
		{
			await _orderService.DeleteOrder(id);

			return NoContent();
		}
	}
}
