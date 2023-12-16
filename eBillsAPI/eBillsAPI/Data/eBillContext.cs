//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using eBill.Models;

//namespace eBill.Data;

//public partial class eBillContext : DbContext
//{
//    public eBillContext(DbContextOptions<eBillContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Bill> Bills { get; set; }

//    public virtual DbSet<Bill1> Bills1 { get; set; }

//    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder
//            .UseCollation("utf8mb4_0900_ai_ci")
//            .HasCharSet("utf8mb4");

//        modelBuilder.Entity<Bill>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.ToTable("bill");

//            entity.HasIndex(e => e.BillId, "IX_bill_BillId");

//            entity.Property(e => e.CreatedDate).HasMaxLength(6);
//            entity.Property(e => e.DueDate).HasMaxLength(6);

//            entity.HasOne(d => d.BillNavigation).WithMany(p => p.InverseBillNavigation).HasForeignKey(d => d.BillId);
//        });

//        modelBuilder.Entity<Bill1>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.ToTable("bills");

//            entity.Property(e => e.Amount).HasPrecision(10, 2);
//            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
//            entity.Property(e => e.DueDate).HasColumnType("datetime");
//            entity.Property(e => e.Name).HasMaxLength(255);
//        });

//        modelBuilder.Entity<EfmigrationsHistory>(entity =>
//        {
//            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

//            entity.ToTable("__EFMigrationsHistory");

//            entity.Property(e => e.MigrationId).HasMaxLength(150);
//            entity.Property(e => e.ProductVersion).HasMaxLength(32);
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}


using eBill.Models;
using Microsoft.EntityFrameworkCore;

namespace eBill.Data;

public class eBillContext : DbContext
{
    public eBillContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Bill> bill { get; set; }
}