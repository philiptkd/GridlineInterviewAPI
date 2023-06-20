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

        public GridlineContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "local.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}