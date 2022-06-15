using RetailInMontionTest.Order.Domain.ValueObjects;
using RetailInMontionTest.SharedDomain;

namespace RetailInMontionTest.Order.Domain.Events
{
    public class OrderCreated : DomainEvent
    {
        public Guid Id { get; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public string Number2 { get; set; }
        public string Country { get; set; }

        public OrderCreated(Guid id, DeliveryAddress address)
        {
            Id = id;
            ZipCode = address.ZipCode;
            Address = address.Address;
            City = address.City;
            Number = address.Number;
            Number2 = address.Number2;
            Country = address.Country;
        }
    }
}
