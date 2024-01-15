using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Parts.API.Domain.Models;

namespace Parts.API.Persistence.Contexts
{
    public partial class PartsDBContext : DbContext
    {
        public PartsDBContext()
        {
        }

        public PartsDBContext(DbContextOptions<PartsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressMail> AddressMail { get; set; }
        public virtual DbSet<AddressPhoneNumber> AddressPhoneNumber { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientAddress> ClientAddress { get; set; }
        public virtual DbSet<Good> Good { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<StatusDelivery> StatusDelivery { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierAddress> SupplierAddress { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-BR05KG5L\\TEST_SQL;Database=PartsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Flat).HasMaxLength(200);

                entity.Property(e => e.House)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<AddressMail>(entity =>
            {
                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.AddressMail)
                    .HasForeignKey(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AddressMa__IdAdd__45F365D3");
            });

            modelBuilder.Entity<AddressPhoneNumber>(entity =>
            {
                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.AddressPhoneNumber)
                    .HasForeignKey(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AddressPh__IdAdd__4316F928");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(2048)
                    .HasDefaultValueSql("('https://img.icons8.com/ios-filled/2x/unsplash.png')");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceDelivery).HasDefaultValueSql("((0.1))");

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Token).HasMaxLength(2048);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Client__IdRole__4BAC3F29");
            });

            modelBuilder.Entity<ClientAddress>(entity =>
            {
                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.ClientAddress)
                    .HasForeignKey(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClientAdd__IdAdd__534D60F1");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.ClientAddress)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClientAdd__IdCli__52593CB8");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Number).HasMaxLength(200);

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(2048)
                    .HasDefaultValueSql("('https://img.icons8.com/ios-filled/2x/unsplash.png')");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Good)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Good__IdCategory__571DF1D5");

                entity.HasOne(d => d.IdManufacturerNavigation)
                    .WithMany(p => p.Good)
                    .HasForeignKey(d => d.IdManufacturer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Good__IdManufact__5629CD9C");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.Good)
                    .HasForeignKey(d => d.IdSupplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Good__IdSupplier__5812160E");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(2048)
                    .HasDefaultValueSql("('https://img.icons8.com/ios-filled/2x/unsplash.png')");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Count)
                    .HasColumnType("numeric(5, 0)")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__IdClient__5EBF139D");

                entity.HasOne(d => d.IdGoodNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdGood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__IdGood__5FB337D6");

                entity.HasOne(d => d.IdOrderDetailsNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdOrderDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__IdOrderDe__619B8048");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__IdSta__5BE2A6F2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<StatusDelivery>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<SupplierAddress>(entity =>
            {
                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.SupplierAddress)
                    .HasForeignKey(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplierA__IdAdd__4F7CD00D");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.SupplierAddress)
                    .HasForeignKey(d => d.IdSupplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SupplierA__IdSup__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
