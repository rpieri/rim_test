using MassTransit;
using RetailInMontionTest.SharedDomain;

namespace RetailInMontionTest.Order.Infra.Messaging
{
    public class MassTransitMessagePublisher : IMessagePublisher
    {
        private readonly ISendEndpointProvider sendEndpointProvider;

        public MassTransitMessagePublisher(ISendEndpointProvider sendEndpointProvider)
        {
            this.sendEndpointProvider = sendEndpointProvider;
        }

        public async Task PublishEventAsync(IReadOnlyCollection<DomainEvent> events)
        {
            foreach (var @event in events)
            {
                var uri = new Uri(Exchanges.ForEvent[@event.GetType().Name]);
                var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(uri);
                await sendEndpoint.Send(@event);
            }
        }
    }
}
