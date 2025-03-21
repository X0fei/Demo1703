﻿using System;
using System.Collections.Generic;
using Demo1703.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1703.Context;

public partial class User18Context : DbContext
{
    public User18Context()
    {
    }

    public User18Context(DbContextOptions<User18Context> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerType> PartnerTypes { get; set; }

    public virtual DbSet<PartnersProduct> PartnersProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=45.67.56.214; Port=5465; Username=user18; Password=0Ewhpxmm; Database=user18");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("material_types_pk");

            entity.ToTable("material_types");

            entity.HasIndex(e => e.Name, "material_types_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DefectPercentage).HasColumnName("defect_percentage");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_pk");

            entity.ToTable("partners");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasColumnType("character varying")
                .HasColumnName("adress");
            entity.Property(e => e.Director)
                .HasColumnType("character varying")
                .HasColumnName("director");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Tin)
                .HasColumnType("character varying")
                .HasColumnName("tin");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("partners_partner_types_fk");
        });

        modelBuilder.Entity<PartnerType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partner_types_pk");

            entity.ToTable("partner_types");

            entity.HasIndex(e => e.Name, "partner_types_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<PartnersProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_products_pk");

            entity.ToTable("partners_products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Partner).HasColumnName("partner");
            entity.Property(e => e.Product).HasColumnName("product");
            entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");
            entity.Property(e => e.SaleDate).HasColumnName("sale_date");

            entity.HasOne(d => d.PartnerNavigation).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.Partner)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("partners_products_partners_fk");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.Product)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("partners_products_products_fk");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pk");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Article)
                .HasColumnType("character varying")
                .HasColumnName("article");
            entity.Property(e => e.MinimalCost).HasColumnName("minimal_cost");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("products_product_types_fk");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_types_pk");

            entity.ToTable("product_types");

            entity.HasIndex(e => e.Name, "product_types_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coefficient).HasColumnName("coefficient");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
