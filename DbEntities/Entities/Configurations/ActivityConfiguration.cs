using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbEntities.Entities.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activity");
            builder.Property(x => x.LastActivity).IsRequired().HasDefaultValue(DateTimeOffset.UtcNow);
            builder.Property(x => x.LoggedInDevices).IsRequired();
        }
    }
}