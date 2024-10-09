using AutoMapper;
using OrderServiceAPI.src.Domain;
using src.Presentation.DTOs.OrderDTOs;

namespace src.Presentation.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<CreateOrderDTO, Order>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.OrderDate, opt => opt.Ignore());
        
        CreateMap<UpdateOrderDTO, Order>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CustomerId, opt => opt.Ignore())
            .ForMember(dest => dest.OrderDate, opt => opt.Ignore());
    }
}
