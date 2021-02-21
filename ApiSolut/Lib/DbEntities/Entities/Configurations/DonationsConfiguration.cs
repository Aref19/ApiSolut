using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbEntities.Entities.Configurations
{
    public class DonationsConfiguration : IEntityTypeConfiguration<Donations>
    {
        public void Configure(EntityTypeBuilder<Donations> builder)
        {
            builder.ToTable("Donations");
            builder.HasKey(x => x.DonationId);
            builder.Property(x => x.DateReceived)
                .HasColumnName("DateReceived")
                .HasColumnType("DateTimeOffset")
                .HasDefaultValue(DateTimeOffset.UtcNow);
            builder.Property(x => x.DonationAmount)
                .HasColumnType("nvarchar")
                .HasMaxLength(3000)
                .IsRequired();
            builder.Property(x => x.DonationType)
                .HasDefaultValue(DonationType.SharingDonation);
        }
    }
}