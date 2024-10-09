using AutoMapper;
using OrderServiceAPI.src.Domain;
using src.Presentation.DTOs.OrderItemDTOs;

namespace src.Presentation.Profiles;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<CreateOrderItemDTO, OrderItem>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
