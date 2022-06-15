using RetailInMontionTest.Order.Domain.Events;

namespace RetailInMontionTest.Order.Infra.Messaging
{
    public static class Exchanges
    {
        public static readonly IReadOnlyDictionary<string, string> ForEvent = new Dictionary<string, string>()
        {
            [nameof(OrderCreated)] = "exchange:retail.in.motion.test.order.created",
            [nameof(OrderUpdated)] = "exchange:retail.in.motion.test.order.updated",
            [nameof(OrderRemoved)] = "exchange:retail.in.motion.test.order.removed",
            [nameof(OrderProductAdded)] = "exchange:retail.in.motion.test.order.product.added",
            [nameof(OrderProductUpdated)] = "exchange:retail.in.motion.test.order.product.updated",
            [nameof(OrderProductRemoved)] = "exchange:retail.in.motion.test.order.product.removed"
        };
    }
}
