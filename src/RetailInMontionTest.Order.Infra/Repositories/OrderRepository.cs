using RetailInMontionTest.Order.Domain;
using RetailInMontionTest.Order.Infra.Contexts;
using RetailInMontionTest.Order.Infra.Messaging;

namespace RetailInMontionTest.Order.Infra.Repositories
{
    public class OrderRepository : Repository<Orders>, IOrderRepository
    {
        public OrderRepository(Context context, IMessagePublisher messagePublisher) : base(context, messagePublisher)
        {
        }
    }
}
