using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AntiaApp.Domain.Entities;

public partial class AntiaAppDbContext : DbContext
{
    public AntiaAppDbContext()
    {
    }

    public AntiaAppDbContext(DbContextOptions<AntiaAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assurance> Assurances { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assurance>(entity =>
        {
            entity.Property(e => e.DateCreation).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Montant).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Statut).HasMaxLength(20);
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasOne(d => d.Client).WithMany(p => p.Assurances)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assurances_Clients");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.Adresse).HasMaxLength(300);
            entity.Property(e => e.DateCreation).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Nom).HasMaxLength(100);
            entity.Property(e => e.Prenom).HasMaxLength(100);
            entity.Property(e => e.Telephone).HasMaxLength(20);

            entity.HasOne(d => d.Site).WithMany(p => p.Clients)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_Sites");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.Property(e => e.Adresse).HasMaxLength(300);
            entity.Property(e => e.Nom).HasMaxLength(200);
            entity.Property(e => e.Telephone).HasMaxLength(20);
            entity.Property(e => e.Ville).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
