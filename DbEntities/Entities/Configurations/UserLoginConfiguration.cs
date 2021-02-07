using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbEntities.Entities.Configurations
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("UserLogin");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Email).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasColumnType("nvarchar").HasMaxLength(2000);
            builder.Property(x => x.EmailConfirmed).HasColumnType("bit");
            builder.Property(x => x.FirstName).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.LastName).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            builder.Ignore(role => role.UserRoles);
        }
    }
}