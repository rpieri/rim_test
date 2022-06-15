using RetailInMontionTest.SharedDomain;

namespace RetailInMontionTest.Order.Infra.Messaging
{
    public interface IMessagePublisher
    {
        Task PublishEventAsync(IReadOnlyCollection<DomainEvent> events);
    }
}
