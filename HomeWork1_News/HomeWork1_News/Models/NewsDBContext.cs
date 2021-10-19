using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HomeWork1_News.Models
{
    public partial class NewsDBContext : DbContext
    {
        public NewsDBContext()
        {
        }

        public NewsDBContext(DbContextOptions<NewsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAdmin> TbAdmins { get; set; }
        public virtual DbSet<TbNews> TbNews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=NewsDB;User=sa;Password=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbAdmin>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__tbAdmin__C9F284577A311D2D");

                entity.ToTable("tbAdmin");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbNews>(entity =>
            {
                entity.HasKey(e => e.NewsId)
                    .HasName("PK__tbNews__954EBDF3D69F72BF");

                entity.ToTable("tbNews");

                entity.Property(e => e.ContentOfNews)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HeadLines)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
