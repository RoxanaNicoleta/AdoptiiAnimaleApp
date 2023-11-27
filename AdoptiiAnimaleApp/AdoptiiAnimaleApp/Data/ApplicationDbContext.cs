using System;
using System.Collections.Generic;
using AdoptiiAnimaleApp.Models.DBObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdoptiiAnimaleApp.Data;

public partial class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adoptii> Adoptiis { get; set; }

    public virtual DbSet<Animale> Animales { get; set; }

   // public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

   // public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

   // public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

   // public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

   // public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

   // public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

   // public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<Utilizatori> Utilizatoris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Adoptii>(entity =>
        {
            entity.HasKey(e => e.Id_adoptie).HasName("PK__Adoptii__2A986C3E8641E07E");

            entity.ToTable("Adoptii");

            entity.Property(e => e.Id_adoptie)
                .ValueGeneratedNever()
                .HasColumnName("ID_adoptie");
            entity.Property(e => e.DataAdoptiei)
                .HasColumnType("datetime")
                .HasColumnName("Data_adoptiei");
            entity.Property(e => e.IdAnimal).HasColumnName("ID_animal");
            entity.Property(e => e.IdUtilizator).HasColumnName("ID_utilizator");
            entity.Property(e => e.StatusAdoptie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Status_adoptie");

            entity.HasOne(d => d.IdAnimalNavigation).WithMany(p => p.Adoptiis)
                .HasForeignKey(d => d.IdAnimal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Adoptii_Animal");

            entity.HasOne(d => d.IdUtilizatorNavigation).WithMany(p => p.Adoptiis)
                .HasForeignKey(d => d.IdUtilizator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Adoptii_Utilizator");
        });

        modelBuilder.Entity<Animale>(entity =>
        {
            entity.HasKey(e => e.IdAnimal);

            entity.ToTable("Animale");

            entity.Property(e => e.IdAnimal)
                .ValueGeneratedNever()
                .HasColumnName("ID_animal");
            entity.Property(e => e.Descriere).IsUnicode(false);
            entity.Property(e => e.Gen)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nume)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nume ");
            entity.Property(e => e.Poza)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Rasa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Specie)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

       /* modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });*/

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.IdFavorit).HasName("PK__Favorite__74E98DB15AACBE91");

            entity.ToTable("Favorite");

            entity.Property(e => e.IdFavorit)
                .ValueGeneratedNever()
                .HasColumnName("ID_favorit");
            entity.Property(e => e.DataAdugare)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Data_adugare");
            entity.Property(e => e.IdAnimal).HasColumnName("ID_animal");
            entity.Property(e => e.IdUtilizator).HasColumnName("ID_utilizator");

            entity.HasOne(d => d.IdAnimalNavigation).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.IdAnimal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorite_Animal");

            entity.HasOne(d => d.IdUtilizatorNavigation).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.IdUtilizator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorite_Utilizator");
        });

      /*  modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC07C368D14E");

            entity.ToTable("Table");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });*/

        modelBuilder.Entity<Utilizatori>(entity =>
        {
            entity.HasKey(e => e.IdUtilizator).HasName("PK__Utilizat__44D06D6633FE6D18");

            entity.ToTable("Utilizatori");

            entity.Property(e => e.IdUtilizator)
                .ValueGeneratedNever()
                .HasColumnName("ID_utilizator");
            entity.Property(e => e.Adresa)
                .HasMaxLength(350)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NrTelefon)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Nr_telefon");
            entity.Property(e => e.Nume)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Parola)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Prenume)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.TipUtilizator)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tip_utilizator");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
