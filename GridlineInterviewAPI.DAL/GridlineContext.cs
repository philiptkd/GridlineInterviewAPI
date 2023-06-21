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

        public string DbPath { get; }

        StreamWriter _writer = new StreamWriter("../GridlineInterviewAPI.DAL/EFCoreLog.txt", append: true);

        public GridlineContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "local.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
            options.LogTo(_writer.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var drivers = new Driver[]
            {
                new Driver { Id = 1, FirstName = "Alice", LastName = "Smith" },
                new Driver { Id = 2, FirstName = "Bob", LastName = "Jones" }
            };

            var trucks = new Truck[]
            {
                new Truck { Id = 1, Make = "Toyota", Model = "BigTruck" },
                new Truck { Id = 2, Make = "Ford", Model = "HugeTruck" }
            };

            modelBuilder.Entity<Driver>().HasData(drivers);
            modelBuilder.Entity<Truck>().HasData(trucks);
        }
    }
}