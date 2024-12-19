using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentService.DBModels;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentDetail> StudentDetails { get; set; }

    public virtual DbSet<StudentMaster> StudentMasters { get; set; }    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentDetail>(entity =>
        {
            entity.HasKey(e => e.DetailsId).HasName("PK_StudentDetails_DetailsID");

            entity.Property(e => e.DetailsId).HasColumnName("DetailsID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.StudentDetails)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentDe__Stude__267ABA7A");
        });

        modelBuilder.Entity<StudentMaster>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_StudentMaster_StudentID");

            entity.ToTable("StudentMaster");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.StudentName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
