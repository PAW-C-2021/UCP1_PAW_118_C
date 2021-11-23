using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UCP1.Models
{
    public partial class UCPContext : DbContext
    {
        public UCPContext()
        {
        }

        public UCPContext(DbContextOptions<UCPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Akun> Akun { get; set; }
        public virtual DbSet<Aplikasi> Aplikasi { get; set; }
        public virtual DbSet<User> User { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.Property(e => e.IdAdmin)
                    .HasColumnName("ID_Admin")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaAdmin)
                    .HasColumnName("Nama_Admin")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Akun>(entity =>
            {
                entity.HasKey(e => e.IdAkun);

                entity.Property(e => e.IdAkun)
                    .HasColumnName("ID_Akun")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Aplikasi>(entity =>
            {
                entity.HasKey(e => e.IdAplikasi);

                entity.Property(e => e.IdAplikasi)
                    .HasColumnName("ID_Aplikasi")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActionGenre)
                    .HasColumnName("Action_Genre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdventureGenre)
                    .HasColumnName("Adventure_Genre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FantasyGenre)
                    .HasColumnName("Fantasy_Genre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser)
                    .HasColumnName("ID_User")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaUser)
                    .HasColumnName("Nama_User")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
