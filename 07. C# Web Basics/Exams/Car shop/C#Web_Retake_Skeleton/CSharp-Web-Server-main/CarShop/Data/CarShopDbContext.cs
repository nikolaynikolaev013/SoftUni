﻿namespace CarShop.Data
{
    using CarShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CarShopDbContext : DbContext
    {
        public DbSet<User> Users { get; init; }

        public DbSet<Car> Cars { get; init; }

        public DbSet<Issue> Issues { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433; Database=CarShop;User=sa; Password=<YourStrong@Passw0rd>");
            }
        }
    }
}