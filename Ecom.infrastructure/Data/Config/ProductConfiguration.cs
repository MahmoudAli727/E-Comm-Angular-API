using Ecom.Core.Entity.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.infrastructure.Data.Config
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(200);
            
            builder.Property(p => p.Description)
                   .HasMaxLength(5000);
            
            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");
            
            builder.HasMany(p => p.Photos)
                   .WithOne(ph => ph.Product)
                   .HasForeignKey(ph => ph.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            //Seed Data
            //builder.HasData(
            //    new Product
            //    {
            //        Id = 1,
            //        Name = "Sample Product 1",
            //        Description = "This is a sample product description.",
            //        Price = 19.99m,
            //        CategoryId = 1
            //    },
            //    new Product
            //    {
            //        Id = 2,
            //        Name = "Sample Product 2",
            //        Description = "This is another sample product description.",
            //        Price = 29.99m,
            //        CategoryId = 2
            //    }
            //);

        }
    }
}
