using DbEntities.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DbEntities
{
    /// <summary>
    /// EF core Migrations require DesignTimeFactory, so we handle a db creation separately for migrating
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseDefaultConnectionConfiguration("Migrations");
            return new AppDbContext(builder.Options);
        }
    }
}