using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public UserEntityConfiguration()
        { }

        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int8");
            builder.Property(x => x.Cpf).HasColumnName("cpf").HasColumnType("varchar(15)");
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(35)");
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(75)");
            builder.Property(x => x.Telephone).HasColumnName("telephone").HasColumnType("varchar(15)");
        }
    }
}
