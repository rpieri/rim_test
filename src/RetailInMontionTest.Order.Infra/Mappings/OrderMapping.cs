using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetailInMontionTest.Order.Domain;

namespace RetailInMontionTest.Order.Infra.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable(nameof(Orders));
            builder.HasKey(e => e.Id);

            builder.OwnsOne(e => e.DeliveryAddress, address =>
            {
                address.Property(a => a.ZipCode).IsRequired();
                address.Property(a => a.Address).IsRequired();
                address.Property(a => a.Number).IsRequired();
                address.Property(a => a.City).IsRequired();
                address.Property(a => a.Country).IsRequired();
                address.Property(a => a.Number2).IsRequired(false);
            });

            builder.HasMany(e => e.Products).WithOne(t => t.Order).HasForeignKey(t => t.OrderId);
            builder.Metadata.FindNavigation(nameof(Orders.Products)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
