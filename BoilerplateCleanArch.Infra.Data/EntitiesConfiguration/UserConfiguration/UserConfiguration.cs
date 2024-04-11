using BoilerplateCleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoilerplateCleanArch.Infra.Data.EntitiesConfiguration.UserConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LastName").HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("varchar").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Token).HasColumnName("Token").HasColumnType("varchar").HasMaxLength(-1);
            builder.Property(x => x.Expiration).HasColumnName("Expiration").HasColumnType("datetime");
            builder.Property(x => x.Active).HasColumnName("Active").HasColumnType("bit").IsRequired();
        }
    }
}
