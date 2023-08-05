using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Configuration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int8");
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(100)");
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("varchar(255)");
            builder.Property(x => x.Price).HasColumnName("price").HasColumnType("money");
            builder.Property(x => x.Stock).HasColumnName("stock").HasColumnType("int2");
            builder.Property(x => x.Status).HasColumnName("status").HasColumnType("numeric(1)").IsRequired();
        }
    }
}
