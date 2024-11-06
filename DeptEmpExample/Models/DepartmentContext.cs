using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DeptEmpExample.Models;

public partial class DepartmentContext : DbContext
{
    public DepartmentContext()
    {
    }

    public DepartmentContext(DbContextOptions<DepartmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Department;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK_Department_1");

            entity.ToTable("Department");

            entity.Property(e => e.DeptId).ValueGeneratedNever();
            entity.Property(e => e.DeptLoc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK_Employee1");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId).ValueGeneratedNever();
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee1_Department");

            entity.HasOne(d => d.Lib).WithMany(p => p.Employees)
                .HasForeignKey(d => d.LibId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee1_Library");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.LibId);

            entity.ToTable("Library");

            entity.Property(e => e.LibId).ValueGeneratedNever();
            entity.Property(e => e.LibAdress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LibName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
