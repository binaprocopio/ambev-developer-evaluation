using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(i => i.ProductId).IsRequired();
            builder.Property(i => i.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Quantity).IsRequired();
            builder.Property(i => i.UnitPrice).IsRequired().HasColumnType("numeric(18,2)");
            builder.Property(i => i.Discount).IsRequired().HasColumnType("numeric(18,2)");

            builder.Property<Guid>("SaleId"); // shadow FK property
        }
    }

}
