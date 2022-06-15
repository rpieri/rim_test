using RetailInMontionTest.SharedDomain;

namespace RetailInMontionTest.Order.Domain.Events
{
    public class OrderProductUpdated : DomainEvent
    {
        public Guid OrderId { get; }
        public Guid ProductId { get; }
        public int Quantity { get; }

        public OrderProductUpdated(Guid orderId, Guid productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
