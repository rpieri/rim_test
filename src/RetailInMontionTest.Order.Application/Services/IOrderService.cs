using RetailInMontionTest.Order.Application.Dtos;

namespace RetailInMontionTest.Order.Application.Services
{
    public interface IOrderService
    {
        Task<OrderResponseDto> Create(OrderCreatedDto requestDto);
        Task<OrderResponseDto> Update(OrderUpdatedDto requestDto);
        Task<OrderResponseDto> Remove(Guid orderId);
    }
}
