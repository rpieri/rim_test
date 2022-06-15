using RetailInMontionTest.SharedDomain;

namespace RetailInMontionTest.Order.Domain.Events
{
    public class OrderRemoved : DomainEvent
    {
        public Guid Guid { get;}

        public OrderRemoved(Guid guid)
        {
            Guid = guid;
        }
    }
}
