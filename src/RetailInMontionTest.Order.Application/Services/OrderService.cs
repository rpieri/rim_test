using RetailInMontionTest.Application.Shared;
using RetailInMontionTest.Order.Application.Dtos;
using RetailInMontionTest.Order.Domain;
using RetailInMontionTest.Order.Domain.ValueObjects;

namespace RetailInMontionTest.Order.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;

        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<OrderResponseDto> Create(OrderCreatedDto requestDto)
        {
            var deliveryOrder = new DeliveryAddress(requestDto.ZipCode, requestDto.Address, requestDto.City, requestDto.Number, requestDto.Number2, requestDto.Country);
            var order = new Orders(deliveryOrder);
            requestDto.Products.ToList().ForEach(product => order.AddProduct(new Product(product.ProductId, product.Quantity, order.Id)));

            await repository.Create(order);

            return new OrderResponseDto(order.Id, "Order was created with success");

        }

        public async Task<OrderResponseDto> Remove(Guid orderId)
        {
            var order = await repository.GetById(orderId);
            if (order is null)
            {
                throw new NotFoundException($"Order: {orderId} was not founded");
            }

            order.Remove();

            await repository.Update(order);

            return new OrderResponseDto(order.Id, "Order was updated with success");

        }

        public async Task<OrderResponseDto> Update(OrderUpdatedDto requestDto)
        {
            var order = await repository.GetById(requestDto.Id); 
            if(order is null)
            {
                throw new NotFoundException($"Order: {requestDto.Id} was not founded");
            }
            var deliveryOrder = new DeliveryAddress(requestDto.ZipCode, requestDto.Address, requestDto.City, requestDto.Number, requestDto.Number2, requestDto.Country);
            order.Update(deliveryOrder);

            requestDto.Products.ToList().ForEach(product =>
            {
                if(product.Id is null)
                {
                    order.AddProduct(new Product(product.ProductId, product.Quantity, order.Id));
                }

                if (product.Removed && product.Id is not null)
                {
                    order.RemoveProduct(product.Id.Value);
                }

                if(product.Id is not null)
                {
                    order.UpdateProduct(product.Id.Value, product.Quantity);
                }
            });

            await repository.Update(order);

            return new OrderResponseDto(order.Id, "Order was updated with success");

        }
    }
}
