using RetailInMontionTest.Order.Domain.Events;
using RetailInMontionTest.Order.Domain.ValueObjects;
using RetailInMontionTest.SharedDomain;

namespace RetailInMontionTest.Order.Domain
{
    public class Orders : Entity
    {
        private readonly List<Product> _products;
        public virtual DeliveryAddress DeliveryAddress { get; private set; }

        public IReadOnlyCollection<Product> Products => _products.Where(t => !t.Removed).ToList();

        private Orders()
        {
            _products = new List<Product>();
        }

        public Orders(DeliveryAddress deliveryAddress)
        {
            DeliveryAddress = deliveryAddress;
            _products = new List<Product>();
            EventsToAdd.Add(new OrderCreated(Id, DeliveryAddress));
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
            EventsToAdd.AddRange(product.Events);
        }

        public void RemoveProduct(Guid productId) 
        {
            var product = _products.SingleOrDefault(x => x.Id == productId);

            if (product is not null)
            {
                product.Remove();
                EventsToAdd.AddRange(product.Events);
            }

        }

        public void Update(DeliveryAddress deliveryAddress)
        {
            if (DeliveryAddress != deliveryAddress)
            {
                DeliveryAddress.Update(deliveryAddress);
                EventsToAdd.Add(new OrderUpdated(Id,DeliveryAddress));
            }
        }

        public void UpdateProduct(Guid productId, int quantity)
        {
            var product = _products.SingleOrDefault(x => x.Id == productId);
            if (product is not null)
            {
                product.Update(quantity);
                EventsToAdd.AddRange(product.Events);
            }            
        }

        public override void Remove()
        {   
            base.Remove();
            EventsToAdd.Add(new OrderRemoved(Id));
        }
    }
}
