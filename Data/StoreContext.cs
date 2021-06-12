using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Store.Models;

#nullable disable

namespace Store.Data
{
    public partial class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartsItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientAddress> ClientsAddresses { get; set; }
        public virtual DbSet<ClientEmail> ClientsEmails { get; set; }
        public virtual DbSet<ClientPhoneNumber> ClientsPhonesNumbers { get; set; }
        public virtual DbSet<CommonProductLeftoversOnPrimaryWarehouse> CommonProductLeftoversOnPrimaryWarehouses { get; set; }
        public virtual DbSet<LeftoversInStore> LeftoversInStores { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrdersItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductKind> ProductsKinds { get; set; }
        public virtual DbSet<Models.Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;database=Store;password=Cyber2001", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FlatNumber).HasColumnType("smallint(6)");

                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PostIndex)
                    .IsRequired()
                    .HasMaxLength(25)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "ClientId");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.ClientId).HasColumnType("bigint(20)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carts_ibfk_1");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasIndex(e => e.CartId, "CartId");

                entity.HasIndex(e => e.ProductId, "ProductId");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.CartId).HasColumnType("bigint(20)");

                entity.Property(e => e.ProductId).HasColumnType("bigint(20)");

                entity.Property(e => e.Quantity).HasColumnType("smallint(6)");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartsItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cartsitems_ibfk_2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartsItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cartsitems_ibfk_1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<ClientAddress>(entity =>
            {
                entity.HasIndex(e => e.AddressId, "AddressId");

                entity.HasIndex(e => e.ClientId, "ClientId");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.AddressId).HasColumnType("bigint(20)");

                entity.Property(e => e.ClientId).HasColumnType("bigint(20)");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.ClientsAddresses)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clientsaddresses_ibfk_2");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientsAddresses)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clientsaddresses_ibfk_1");
            });

            modelBuilder.Entity<ClientEmail>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "ClientId");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.ClientId).HasColumnType("bigint(20)");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientsEmails)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clientsemails_ibfk_1");
            });

            modelBuilder.Entity<ClientPhoneNumber>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "ClientId");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.ClientId).HasColumnType("bigint(20)");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientsPhonesNumbers)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clientsphonesnumbers_ibfk_1");
            });

            modelBuilder.Entity<CommonProductLeftoversOnPrimaryWarehouse>(entity =>
            {
                entity.ToTable("CommonProductLeftoversOnPrimaryWarehouse");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.ProductId).HasColumnType("bigint(20)");

                entity.Property(e => e.Quantity).HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<LeftoversInStore>(entity =>
            {
                entity.ToTable("LeftoversInStore");

                entity.HasIndex(e => e.ProductId, "ProductId");

                entity.HasIndex(e => e.StoreId, "StoreId");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.ProductId).HasColumnType("bigint(20)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.StoreId).HasColumnType("bigint(20)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LeftoversInStores)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leftoversinstore_ibfk_1");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.LeftoversInStores)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leftoversinstore_ibfk_2");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.ClientAddressId).HasColumnType("bigint(20)");

                entity.Property(e => e.IsCompleted).HasColumnType("bit(1)");

                entity.Property(e => e.OrderingDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasIndex(e => e.OrderId, "OrderId");

                entity.HasIndex(e => e.ProductId, "ProductId");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.OrderId).HasColumnType("bigint(20)");

                entity.Property(e => e.ProductId).HasColumnType("bigint(20)");

                entity.Property(e => e.Quantity).HasColumnType("smallint(6)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ordersitems_ibfk_2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrdersItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ordersitems_ibfk_1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "CategoryId");

                entity.HasIndex(e => e.ManufacturerId, "ManufacturerId");

                entity.HasIndex(e => e.ProductKindId, "ProductKindId");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.Property(e => e.ManufacturerId).HasColumnType("int(11)");

                entity.Property(e => e.ProductKindId).HasColumnType("int(11)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_ibfk_1");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_ibfk_2");

                entity.HasOne(d => d.ProductKind)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductKindId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_ibfk_3");
            });

            modelBuilder.Entity<ProductKind>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.KindName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Store.Models.Store>(entity =>
            {
                entity.HasIndex(e => e.AddressId, "AddressId");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.AddressId).HasColumnType("bigint(20)");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stores_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
