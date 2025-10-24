using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Srez1.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialSupplier> MaterialSuppliers { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductMaterial> ProductMaterials { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierType> SupplierTypes { get; set; }

    public virtual DbSet<UnitType> UnitTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Srez;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Явно игнорируем CalculatedCost - оно не должно сохраняться в БД
        modelBuilder.Entity<Product>()
            .Ignore(p => p.CalculatedCost);

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("material_pkey");

            entity.ToTable("material");

            entity.HasIndex(e => e.Name, "material_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MinQuantity)
                .HasPrecision(12, 2)
                .HasColumnName("min_quantity");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.PackQuantity)
                .HasPrecision(12, 2)
                .HasColumnName("pack_quantity");
            entity.Property(e => e.Price)
                .HasPrecision(12, 2)
                .HasColumnName("price");
            entity.Property(e => e.StockQuantity)
                .HasPrecision(12, 2)
                .HasColumnName("stock_quantity");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Materials)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("material_type_id_fkey");

            entity.HasOne(d => d.Unit).WithMany(p => p.Materials)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("material_unit_id_fkey");
        });

        modelBuilder.Entity<MaterialSupplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("material_supplier_pkey");

            entity.ToTable("material_supplier");

            entity.HasIndex(e => new { e.MaterialId, e.SupplierId }, "material_supplier_material_id_supplier_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

            entity.HasOne(d => d.Material).WithMany(p => p.MaterialSuppliers)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("material_supplier_material_id_fkey");

            entity.HasOne(d => d.Supplier).WithMany(p => p.MaterialSuppliers)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("material_supplier_supplier_id_fkey");
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("material_type_pkey");

            entity.ToTable("material_type");

            entity.HasIndex(e => e.Name, "material_type_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LosePercentage)
                .HasPrecision(6, 4)
                .HasColumnName("lose_percentage");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.ToTable("product");

            entity.HasIndex(e => e.Name, "product_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MinPartnerPrice)
                .HasPrecision(12, 2)
                .HasColumnName("min_partner_price");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Param1)
                .HasPrecision(12, 2)
                .HasColumnName("param1");
            entity.Property(e => e.Param2)
                .HasPrecision(12, 2)
                .HasColumnName("param2");
            entity.Property(e => e.RollWidth)
                .HasPrecision(12, 2)
                .HasColumnName("roll_width");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_type_id_fkey");
        });

        modelBuilder.Entity<ProductMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_material_pkey");

            entity.ToTable("product_material");

            entity.HasIndex(e => new { e.ProductId, e.MaterialId }, "product_material_product_id_material_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.MaterialQty)
                .HasPrecision(12, 2)
                .HasColumnName("material_qty");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Material).WithMany(p => p.ProductMaterials)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("product_material_material_id_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductMaterials)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("product_material_product_id_fkey");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_type_pkey");

            entity.ToTable("product_type");

            entity.HasIndex(e => e.Name, "product_type_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CoeffType)
                .HasPrecision(8, 3)
                .HasColumnName("coeff_type");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("suppliers_pkey");

            entity.ToTable("suppliers");

            entity.HasIndex(e => e.Inn, "suppliers_inn_key").IsUnique();

            entity.HasIndex(e => e.Name, "suppliers_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Inn)
                .HasMaxLength(20)
                .HasColumnName("inn");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("suppliers_type_id_fkey");
        });

        modelBuilder.Entity<SupplierType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supplier_type_pkey");

            entity.ToTable("supplier_type");

            entity.HasIndex(e => e.Name, "supplier_type_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<UnitType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("unit_type_pkey");

            entity.ToTable("unit_type");

            entity.HasIndex(e => e.Name, "unit_type_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
