using RetailInMontionTest.SharedDomain;

namespace RetailInMontionTest.Order.Domain.Events
{
    public class OrderProductRemoved : DomainEvent
    {
        public Guid OrderId { get; }
        public Guid ProductId { get; }
        public OrderProductRemoved(Guid orderId, Guid productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
