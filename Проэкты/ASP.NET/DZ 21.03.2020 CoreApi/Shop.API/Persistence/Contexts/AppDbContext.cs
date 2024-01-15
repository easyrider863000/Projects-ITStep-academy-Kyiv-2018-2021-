using System;
using Microsoft.EntityFrameworkCore;
using Shop.API.Domain.Models;

namespace Shop.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Good> Goods { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(x => x.Id);
            builder.Entity<Category>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 10000, Name = "Notebook"},
                new Category { Id = 10001, Name = "Smartphone"}
            );

            // builder.Entity<Good>().ToTable("Goods");
            // builder.Entity<Good>().HasKey(x => x.Id);
            // builder.Entity<Good>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            // builder.Entity<Good>().Property(x => x.GoodName).IsRequired().HasMaxLength(50);
            
            







            

            builder.Entity<Manufacturer>().ToTable("Manufacturers");
            builder.Entity<Manufacturer>().HasKey(x => x.Id);
            builder.Entity<Manufacturer>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Manufacturer>().Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.Entity<Manufacturer>().HasData
            (
                new Manufacturer { Id = 100, Name = "Apple"},
                new Manufacturer { Id = 101, Name = "Samsung"},
                new Manufacturer { Id = 102, Name = "HP"}
            );

            builder.Entity<Good>().ToTable("Goods");
            builder.Entity<Good>().HasKey(x => x.Id);
            builder.Entity<Good>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Good>().Property(x => x.GoodName).IsRequired().HasMaxLength(50);
            
            builder.Entity<Good>().HasData
            (
                new Good { Id = 100, GoodName = "Pistolet", GoodCount=1,Price=10.01, CategoryId=10000, ManufacturerId=100}
            );
        }

    }
}