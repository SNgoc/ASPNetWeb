using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DemoAuthorization.Models
{
    public partial class DemoLoginContext : DbContext
    {
        public DemoLoginContext()
        {
        }

        public DemoLoginContext(DbContextOptions<DemoLoginContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountRole> AccountRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Name=ConnectionStrings:DemoLoginConnection");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Fullname).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.RoleId })
                    .HasName("PK__Account___8C320947AAB20B4F");

                entity.ToTable("Account_Role");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountRoles)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AccountRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
