using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Configuration
{
    public class OrderProductEntityConfiguration : IEntityTypeConfiguration<OrderProductEntity>
    {
        public void Configure(EntityTypeBuilder<OrderProductEntity> builder)
        {
            builder.ToTable("orderproduct");
            builder.HasKey(t => t.Id);

            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int8");
            builder.Property(x => x.OrderNumber).HasColumnName("ordernumber").HasColumnType("uuid").IsRequired();
            builder.Property(x => x.IdProduct).HasColumnName("idproduct").HasColumnType("int8").IsRequired();
        }
    }
}
