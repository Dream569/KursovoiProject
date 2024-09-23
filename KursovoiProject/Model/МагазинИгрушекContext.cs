using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KursovoiProject.Model;

public partial class МагазинИгрушекContext : DbContext
{
    public МагазинИгрушекContext()
    {
    }

    public МагазинИгрушекContext(DbContextOptions<МагазинИгрушекContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<КоличествоТоваров> КоличествоТоваровs { get; set; }

    public virtual DbSet<Поставщик> Поставщикs { get; set; }

    public virtual DbSet<Продажи> Продажиs { get; set; }

    public virtual DbSet<Склад> Складs { get; set; }

    public virtual DbSet<Товары> Товарыs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=МагазинИгрушек; User=ИСП-41; Password=1234567890; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasOne(d => d.UserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<КоличествоТоваров>(entity =>
        {
            entity.HasKey(e => new { e.НомерТовара, e.КодПоставщика });

            entity.ToTable("КоличествоТоваров");

            entity.HasOne(d => d.КодПоставщикаNavigation).WithMany(p => p.КоличествоТоваровs)
                .HasForeignKey(d => d.КодПоставщика)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_КоличествоТоваров_Поставщик");

            entity.HasOne(d => d.НомерТовараNavigation).WithMany(p => p.КоличествоТоваровs)
                .HasForeignKey(d => d.НомерТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_КоличествоТоваров_Товары");
        });

        modelBuilder.Entity<Поставщик>(entity =>
        {
            entity.HasKey(e => e.Код);

            entity.ToTable("Поставщик");
        });

        modelBuilder.Entity<Продажи>(entity =>
        {
            entity.HasKey(e => e.НомерЧека);

            entity.ToTable("Продажи");

            entity.Property(e => e.ДатаПродажи).HasColumnType("datetime");

            entity.HasOne(d => d.КодТовараNavigation).WithMany(p => p.Продажиs)
                .HasForeignKey(d => d.КодТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Продажи_Товары");
        });

        modelBuilder.Entity<Склад>(entity =>
        {
            entity.HasKey(e => e.НомерСклада).HasName("PK_Склад_1");

            entity.ToTable("Склад");

            entity.Property(e => e.Фиодиректора).HasColumnName("ФИОДиректора");

            entity.HasOne(d => d.КодТовараNavigation).WithMany(p => p.Складs)
                .HasForeignKey(d => d.КодТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Склад_Товары");
        });

        modelBuilder.Entity<Товары>(entity =>
        {
            entity.HasKey(e => e.Номер);

            entity.ToTable("Товары");

            entity.Property(e => e.Цена).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
