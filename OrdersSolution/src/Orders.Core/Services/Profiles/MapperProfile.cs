using AutoMapper;
using Orders.Core.Domain.Entities.Orders;
using Orders.Core.DTO.Order;
using Orders.Core.DTO.OrderItem;

namespace Orders.Core.Services.Profiles
{
	internal class MapperProfile : Profile
	{
        public MapperProfile()
        {
            CreateMap<Order, OrderResponse>();
			CreateMap<OrderResponse, Order>();
			CreateMap<OrderItemAddRequest, OrderItem>();
			CreateMap<OrderItem, OrderItemResponse>();
		}
	}
}
