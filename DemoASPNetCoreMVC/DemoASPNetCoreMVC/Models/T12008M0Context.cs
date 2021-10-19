using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DemoASPNetCoreMVC.Models
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=T12008M0;User=sa;Password=1");
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
