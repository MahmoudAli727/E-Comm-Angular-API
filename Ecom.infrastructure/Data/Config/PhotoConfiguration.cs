
using Ecom.Core.Entity.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.infrastructure.Data.Config
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(ph => ph.Id);

            builder.HasOne(ph => ph.Product)
                   .WithMany(p => p.Photos)
                   .HasForeignKey(ph => ph.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new Photo
            {
                Id = 1,
                ImageName = "product1_img1.jpg",
                ProductId = 1
            }
            );
        }
    }
}
