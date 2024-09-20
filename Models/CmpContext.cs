using System;
using System.Collections.Generic;
using CMP.Models;
using Microsoft.EntityFrameworkCore;

namespace CMP.Models;

public partial class CmpContext : DbContext
{
    public CmpContext()
    {
    }

    public CmpContext(DbContextOptions<CmpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchaseorder> Purchaseorders { get; set; }

    public virtual DbSet<Purchaseorderdetail> Purchaseorderdetails { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseController> WarehouseControllers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LF3J2AJ;TrustServerCertificate=True\n;Database=cmp;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB9DA615B409");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customerID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Customer__0809337D725CD43C");

            entity.ToTable("CustomerOrder");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("orderID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchaseDate");
            entity.Property(e => e.Totalamount).HasColumnName("totalamount");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("customerID");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__Orderdet__E4FEDE2A2E9FD112");

            entity.Property(e => e.OrderDetailId)
                .ValueGeneratedNever()
                .HasColumnName("orderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.ProductId).HasColumnName("productID");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Orderdeta__produ__403A8C7D");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Orderdeta__produ__412EB0B6");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__product__B40CC6ED84689EFD");

            entity.ToTable("product");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.Color)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Purchaseorder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__purchase__0809337D048434BF");

            entity.ToTable("purchaseorder");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("orderID");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchaseDate");
            entity.Property(e => e.Totalamount).HasColumnName("totalamount");
            entity.Property(e => e.VendorId).HasColumnName("vendorID");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Purchaseorders)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK__purchaseo__vendo__49C3F6B7");
        });

        modelBuilder.Entity<Purchaseorderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderdetailsId).HasName("PK__purchase__64979338D2C74D2F");

            entity.ToTable("purchaseorderdetails");

            entity.Property(e => e.OrderdetailsId)
                .ValueGeneratedNever()
                .HasColumnName("orderdetailsID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.ProductId).HasColumnName("productID");

            entity.HasOne(d => d.Order).WithMany(p => p.Purchaseorderdetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__purchaseo__order__571DF1D5");

            entity.HasOne(d => d.Product).WithMany(p => p.Purchaseorderdetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__purchaseo__produ__5812160E");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendor__EC65C4E38FBF2E05");

            entity.ToTable("Vendor");

            entity.Property(e => e.VendorId)
                .ValueGeneratedNever()
                .HasColumnName("vendorID");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Whnumber).HasName("PK__Warehous__6F827DFB98E880E0");

            entity.ToTable("Warehouse");

            entity.Property(e => e.Whnumber)
                .ValueGeneratedNever()
                .HasColumnName("WHnumber");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("location");
        });

        modelBuilder.Entity<WarehouseController>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WarehouseController");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Whnumber).HasColumnName("WHnumber");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Warehouse__produ__44FF419A");

            entity.HasOne(d => d.WhnumberNavigation).WithMany()
                .HasForeignKey(d => d.Whnumber)
                .HasConstraintName("FK__Warehouse__WHnum__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
