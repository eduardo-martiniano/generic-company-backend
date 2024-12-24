using Domain.Features.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class ProductEntityMapping : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("products", "public");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired(false);

            builder.Property(x => x.Price)
                .HasColumnName("price")
                .IsRequired();

            builder.Property(x => x.Active)
                .HasColumnName("active")
                .IsRequired(true);

            builder.Property(x => x.CreatedDate)
                .HasColumnName("created_date")
                .IsRequired(true);

            builder.Property(x => x.UpdatedDate)
                .HasColumnName("updated_date");
        }
    }
}
