using Microsoft.EntityFrameworkCore;
using RetailInMontionTest.Order.Domain;

namespace RetailInMontionTest.Order.Infra.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
    }
}
