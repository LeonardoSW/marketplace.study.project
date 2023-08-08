using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Configuration
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public OrderEntityConfiguration()
        { }

        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("orders");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int8");
            builder.Property(x => x.CreateDate).HasColumnName("createdate").HasColumnType("timestamp");
            builder.Property(x => x.OrderNumber).HasColumnName("ordernumber").HasColumnType("uuid");
            builder.Property(x => x.Status).HasColumnName("status").HasColumnType("numeric(1)");
        }
    }
}
