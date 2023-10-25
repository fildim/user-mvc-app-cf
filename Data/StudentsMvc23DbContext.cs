using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UserMvcApp.Data;

public partial class StudentsMvc23DbContext : DbContext
{
    public StudentsMvc23DbContext()
    {
    }

    public StudentsMvc23DbContext(DbContextOptions<StudentsMvc23DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC27E373172F");

            entity.ToTable("STUDENTS");

            entity.HasIndex(e => e.UserId, "UQ_STUDENTS_USER_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.UserId)
                .HasConstraintName("FK_STUDENTS_To_USERS");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USERS");

            entity.ToTable("USERS");

            entity.HasIndex(e => e.Lastname, "IX_LASTNAME");

            entity.HasIndex(e => e.Email, "UQ_USERS_EMAIL").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ_USERS_PHONE").IsUnique();

            entity.HasIndex(e => e.Username, "UQ_USERS_USERNAME").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Institution)
                .HasMaxLength(50)
                .HasColumnName("INSTITUTION");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Password)
                .HasMaxLength(512)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .HasColumnName("USER_ROLE");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("USERNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
