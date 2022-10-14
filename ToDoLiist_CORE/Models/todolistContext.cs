using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ToDoList.Models
{
    public partial class todolistContext : DbContext
    {
        public todolistContext()
        {
        }

        public todolistContext(DbContextOptions<todolistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySQL("Server=localhost;port=3306;user=root;password=Manager@123456;database=todolist;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>(entity =>
            {
                entity.ToTable("todo");

                entity.HasIndex(e => e.IdUser, "user_todo_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Archived)
                    .HasColumnType("tinyint")
                    .HasColumnName("archived");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("content")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int unsigned")
                    .HasColumnName("iduser");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .HasColumnName("image");

                entity.Property(e => e.IsRead).HasColumnName("isRead");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Todos)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_todo");
                entity.Property(e => e.CreatedDate)
                   .HasColumnName("CraetedDate")
                   .HasColumnType("timestamp")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedDate)
                      .HasColumnName("UpdatedDate")
                      .HasColumnType("timestamp")
                      .ValueGeneratedOnAddOrUpdate()
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Archived)
                   .HasColumnType("tinyint")
                   .HasColumnName("archived");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Archived)
                    .HasColumnType("tinyint")
                    .HasColumnName("archived");

                entity.Property(e => e.ConfPassword)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("confPassword");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("firstName")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("image");

                entity.Property(e => e.IsAdmin)
                    .HasColumnType("tinyint")
                    .HasColumnName("isAdmin");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("lastName")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("password");
                entity.Property(e => e.CreatedDate)
                   .HasColumnName("CraetedDate")
                   .HasColumnType("timestamp")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedDate)
                      .HasColumnName("UpdatedDate")
                      .HasColumnType("timestamp")
                      .ValueGeneratedOnAddOrUpdate()
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
