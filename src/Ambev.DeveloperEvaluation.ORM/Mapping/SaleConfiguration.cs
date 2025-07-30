using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            // Primary Key
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()");

            // Auto-incremented SaleNumber
            builder.Property(s => s.SaleNumber)
                   .IsRequired()
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn(); // For PostgreSQL or SQL Server

            builder.Property(s => s.SaleDate)
                   .IsRequired();

            builder.Property(s => s.CustomerId)
                   .IsRequired();

            builder.Property(s => s.CustomerName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.BranchId)
                   .IsRequired();

            builder.Property(s => s.BranchName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.IsCanceled)
                   .IsRequired();

            // Relationship: Sale has many SaleItems
            builder.HasMany(s => s.Items)
                   .WithOne()
                   .HasForeignKey("SaleId") // shadow property
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
