using System;
using System.Reflection;
using DbEntities.Entities;
using DbEntities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DbEntities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<UserLogin> UserLogin { get; set; } //UserLogin Table
        public DbSet<Activity> UserActivity { get; set; } //Activity Table
        public DbSet<Donations> Donations { get; set; }
        public DbSet<Address> Address { get; set; }
        // public DbSet<UserRoles> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseDefaultConnectionConfiguration("Migrations");
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AppDbContext)) ??
                                                         throw new Exception(
                                                             "Database failed to get initialized on model creating builder."));
        }
    }
}