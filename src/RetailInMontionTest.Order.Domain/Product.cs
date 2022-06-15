using RetailInMontionTest.Order.Domain.Events;
using RetailInMontionTest.SharedDomain;

namespace RetailInMontionTest.Order.Domain
{
    public class Product : Entity
    {
        public Guid ProductId { get; }
        public int Quantity { get; private set; }

        public Guid OrderId { get; }
        public Orders Order { get; }

        private Product()
        {
        }

        public Product(Guid productId, int quantity, Guid orderId)
        {
            ProductId = productId;
            Quantity = quantity;
            OrderId = orderId;
            EventsToAdd.Add(new OrderProductAdded(OrderId, ProductId, Quantity));
        }

        public void Update(int quantity) 
        {
            if (Quantity != quantity)
            {
                Quantity = quantity;
                EventsToAdd.Add(new OrderProductUpdated(OrderId, ProductId, Quantity));
            }
        }

        public override void Remove()
        {
            EventsToAdd.Add(new OrderProductRemoved(OrderId, ProductId));
            base.Remove();
        }
    }
}
