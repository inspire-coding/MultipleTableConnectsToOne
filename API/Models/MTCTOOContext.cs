using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class MTCTOOContext : DbContext
    {
        public MTCTOOContext()
        {
        }

        public MTCTOOContext(DbContextOptions<MTCTOOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tutorial> Tutorials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data source=MTCTOO.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Currency).HasColumnType("VARCHAR(50)");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Excerpt)
                    .IsRequired()
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Tutorial>(entity =>
            {
                entity.ToTable("Tutorial");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Currency)
                    .HasColumnType("VARCHAR(3)")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Tutorials)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
