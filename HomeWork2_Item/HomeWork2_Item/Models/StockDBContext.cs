using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HomeWork2_Item.Models
{
    public partial class StockDBContext : DbContext
    {
        public StockDBContext()
        {
        }

        public StockDBContext(DbContextOptions<StockDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=StockDB;User=sa;Password=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Account__536C85E5C5F8123D");

                entity.ToTable("Account");

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemCode)
                    .HasName("PK__Items__3ECC0FEB1053EB7C");

                entity.Property(e => e.ItemCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_Item_Account");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
