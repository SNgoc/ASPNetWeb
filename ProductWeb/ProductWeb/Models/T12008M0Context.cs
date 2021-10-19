using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProductWeb.Models
{
    public partial class T12008M0Context : DbContext
    {
        public T12008M0Context()
        {
        }

        public T12008M0Context(DbContextOptions<T12008M0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<CategoryDetail> CategoryDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=T12008M0;User=sa;Password=1");
                //optionsBuilder.UseSqlServer("Name=ConnectionStrings:T12008M0Connection");   
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CatId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CatID");

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_CatCode");
            });

            modelBuilder.Entity<CategoryDetail>(entity =>
            {
                entity.HasKey(e => e.CatCode)
                    .HasName("PK__Category__5E593E4FC59AFC60");

                entity.Property(e => e.CatCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CatDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
