using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbEntities.Entities.Configurations
{
    public class AddressConfiguration: IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(x => x.AddressId);
            builder.Property(x => x.City).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Country).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.State).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Street).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.HouseNr).HasColumnType("nvarchar").HasMaxLength(10).IsRequired();
        }
    }
}