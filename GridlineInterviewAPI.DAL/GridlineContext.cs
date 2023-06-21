using Microsoft.EntityFrameworkCore;
using GridlineInterviewAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace GridlineInterviewAPI.DAL
{
    public class GridlineContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        public GridlineContext(DbContextOptions<GridlineContext> options) : base(options) { }

        // adds Created and Modified audit fields to both entities
        //   despite them not existing on the classes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().Property<DateTime>("Audit_Created");
            modelBuilder.Entity<Driver>().Property<DateTime>("Audit_Modified");

            modelBuilder.Entity<Truck>().Property<DateTime>("Audit_Created");
            modelBuilder.Entity<Truck>().Property<DateTime>("Audit_Modified");
        }

        // automatically populates "shadow" properties Audit_Modified and Audit_Created
        public override int SaveChanges()
        {
            var timestamp = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Property("Audit_Modified").CurrentValue = timestamp;
                if (entry.State == EntityState.Added)
                    entry.Property("Audit_Created").CurrentValue = timestamp;
            }
            return base.SaveChanges();
        }
    }
}