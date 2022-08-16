using EventBus.Message.Events;
using Ordering.Application.Features.Orders.CheckoutOrder;
using AutoMapper;

namespace Ordering.API.Mapping
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
