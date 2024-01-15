using System;
using Microsoft.EntityFrameworkCore;
using Shop.API.Domain.Models;

namespace Shop.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Good> Goods { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(x => x.Firstname).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(x => x.Lastname).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(x => x.Login).IsRequired().HasMaxLength(30);
            builder.Entity<User>().HasAlternateKey(x => x.Login);
            builder.Entity<User>().Property(x => x.Password).IsRequired().HasMaxLength(30);

            builder.Entity<User>().HasData
            (
                new User 
                {
                    Id = 777, 
                    Firstname = "Людмила", 
                    Lastname= "Богданова", 
                    Login="Corolla",
                    Password="Corolla123",
                    Role = "corolla_driver"
                },
                new User 
                {
                    Id = 666, 
                    Firstname = "Дмитрий", 
                    Lastname= "Евгеньевич", 
                    Login="lexus",
                    Password="lexusbetterthancorolla",
                    Role = "lexus_driver"
                },
                new User 
                {
                    Id = 333, 
                    Firstname = "Admin", 
                    Lastname= "Adminovich", 
                    Login="admin",
                    Password="adminadmin",
                    Role = "admin"
                }
            );


            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(x => x.Id);
            builder.Entity<Category>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 10000, Name = "Notebook" },
                new Category { Id = 10001, Name = "Smartphone" }
            );

            builder.Entity<Good>().ToTable("Goods");
            builder.Entity<Good>().HasKey(x => x.Id);
            builder.Entity<Good>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Good>().Property(x => x.GoodName).IsRequired().HasMaxLength(50);



        }

    }
}