using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetailInMontionTest.Order.Domain;

namespace RetailInMontionTest.Order.Infra.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(e => e.Id);
            builder.Property(e => e.ProductId).IsRequired();
            builder.Property(e => e.Quantity).IsRequired();
        }
    }
}
