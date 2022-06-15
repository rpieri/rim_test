using Microsoft.EntityFrameworkCore;
using RetailInMontionTest.Order.Infra.Contexts;
using RetailInMontionTest.Order.Infra.Messaging;
using RetailInMontionTest.SharedDomain;

namespace RetailInMontionTest.Order.Infra.Repositories
{
    public abstract class Repository<T> where T : Entity
    {
        private readonly Context context;
        private readonly DbSet<T> dbSet;
        private readonly IMessagePublisher messagePublisher;

        protected Repository(Context context, IMessagePublisher messagePublisher)
        {
            this.context = context;
            dbSet = context.Set<T>();
            this.messagePublisher = messagePublisher;
        }

        public async Task<T?> GetById(Guid id) => await dbSet.FirstOrDefaultAsync(e => e.Id == id);
        public async Task Create(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAndPublishEvents(entity);
        }

        public async Task Update(T entity)
        {
            dbSet.Update(entity);
            await SaveAndPublishEvents(entity);
        }

        private async Task SaveAndPublishEvents(T entity)
        {
            await context.SaveChangesAsync();
            await messagePublisher.PublishEventAsync(entity.Events);
        }
    }
}
