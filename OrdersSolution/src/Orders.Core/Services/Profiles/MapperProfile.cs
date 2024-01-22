using AutoMapper;
using Orders.Core.Domain.Entities.Orders;
using Orders.Core.DTO.Order;

namespace Orders.Core.Services.Profiles
{
	internal class MapperProfile : Profile
	{
        public MapperProfile()
        {
            CreateMap<Order, OrderResponse>();
			CreateMap<OrderResponse, Order>();
		}
    }
}
