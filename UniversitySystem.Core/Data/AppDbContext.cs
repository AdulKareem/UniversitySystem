using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Core.Models;

namespace UniversitySystem.Core.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Sectionschedule> Sectionschedules { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("UNIVERSITY_USER")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Courseid).HasName("SYS_C008246");

            entity.ToTable("COURSES");

            entity.HasIndex(e => e.Departmentid, "IX_COURSES_DEPT");

            entity.HasIndex(e => e.Coursecode, "SYS_C008247").IsUnique();

            entity.Property(e => e.Courseid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("COURSEID");
            entity.Property(e => e.Coursecode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("COURSECODE");
            entity.Property(e => e.Coursedescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("COURSEDESCRIPTION");
            entity.Property(e => e.Coursename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COURSENAME");
            entity.Property(e => e.Credithours)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("CREDITHOURS");
            entity.Property(e => e.Departmentid)
                .HasColumnType("NUMBER")
                .HasColumnName("DEPARTMENTID");
            entity.Property(e => e.Isfeatured)
                .IsRequired()
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER(1)")
                .HasColumnName("ISFEATURED");

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .HasForeignKey(d => d.Departmentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COURSES_DEPT");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Departmentid).HasName("SYS_C008236");

            entity.ToTable("DEPARTMENTS");

            entity.HasIndex(e => e.Departmentname, "SYS_C008237").IsUnique();

            entity.Property(e => e.Departmentid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("DEPARTMENTID");
            entity.Property(e => e.Departmentname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENTNAME");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.Instructorid).HasName("SYS_C008253");

            entity.ToTable("INSTRUCTORS");

            entity.HasIndex(e => e.Email, "SYS_C008254").IsUnique();

            entity.Property(e => e.Instructorid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("INSTRUCTORID");
            entity.Property(e => e.Departmentid)
                .HasColumnType("NUMBER")
                .HasColumnName("DEPARTMENTID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FULLNAME");

            entity.HasOne(d => d.Department).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.Departmentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSTRUCTORS_DEPT");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.Registrationid).HasName("SYS_C008292");

            entity.ToTable("REGISTRATIONS");

            entity.HasIndex(e => e.Sectionid, "IX_REG_SECTION");

            entity.HasIndex(e => new { e.Studentid, e.Sectionid }, "UQ_REG_STUDENT_SECTION").IsUnique();

            entity.Property(e => e.Registrationid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("REGISTRATIONID");
            entity.Property(e => e.Registrationdate)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE")
                .HasColumnName("REGISTRATIONDATE");
            entity.Property(e => e.Registrationstatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("'Registered' ")
                .HasColumnName("REGISTRATIONSTATUS");
            entity.Property(e => e.Sectionid)
                .HasColumnType("NUMBER")
                .HasColumnName("SECTIONID");
            entity.Property(e => e.Studentid)
                .HasColumnType("NUMBER")
                .HasColumnName("STUDENTID");

            entity.HasOne(d => d.Section).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.Sectionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REG_SECTION");

            entity.HasOne(d => d.Student).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.Studentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REG_STUDENT");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("SYS_C008222");

            entity.ToTable("ROLES");

            entity.HasIndex(e => e.Rolename, "SYS_C008223").IsUnique();

            entity.Property(e => e.Roleid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Sectionid).HasName("SYS_C008272");

            entity.ToTable("SECTIONS");

            entity.HasIndex(e => e.Instructorid, "IX_SECTIONS_INSTR");

            entity.HasIndex(e => new { e.Courseid, e.Sectionnumber }, "UQ_SECTIONS_COURSE_NO").IsUnique();

            entity.Property(e => e.Sectionid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("SECTIONID");
            entity.Property(e => e.Capacity)
                .HasPrecision(3)
                .HasColumnName("CAPACITY");
            entity.Property(e => e.Courseid)
                .HasColumnType("NUMBER")
                .HasColumnName("COURSEID");
            entity.Property(e => e.Instructorid)
                .HasColumnType("NUMBER")
                .HasColumnName("INSTRUCTORID");
            entity.Property(e => e.Sectionnumber)
                .HasPrecision(3)
                .HasColumnName("SECTIONNUMBER");

            entity.HasOne(d => d.Course).WithMany(p => p.Sections)
                .HasForeignKey(d => d.Courseid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SECTIONS_COURSE");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Sections)
                .HasForeignKey(d => d.Instructorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SECTIONS_INSTRUCTOR");
        });

        modelBuilder.Entity<Sectionschedule>(entity =>
        {
            entity.HasKey(e => e.Scheduleid).HasName("SYS_C008284");

            entity.ToTable("SECTIONSCHEDULES");

            entity.HasIndex(e => e.Sectionid, "IX_SCHEDULE_SECT");

            entity.Property(e => e.Scheduleid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("SCHEDULEID");
            entity.Property(e => e.Dayofweek)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DAYOFWEEK");
            entity.Property(e => e.Endtime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ENDTIME");
            entity.Property(e => e.Roomnumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ROOMNUMBER");
            entity.Property(e => e.Sectionid)
                .HasColumnType("NUMBER")
                .HasColumnName("SECTIONID");
            entity.Property(e => e.Starttime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("STARTTIME");

            entity.HasOne(d => d.Section).WithMany(p => p.Sectionschedules)
                .HasForeignKey(d => d.Sectionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SCHEDULE_SECTION");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("SYS_C008261");

            entity.ToTable("STUDENTS");

            entity.HasIndex(e => e.Universityid, "SYS_C008262").IsUnique();

            entity.HasIndex(e => e.Email, "SYS_C008263").IsUnique();

            entity.Property(e => e.Studentid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("STUDENTID");
            entity.Property(e => e.Departmentid)
                .HasColumnType("NUMBER")
                .HasColumnName("DEPARTMENTID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Universityid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UNIVERSITYID");

            entity.HasOne(d => d.Department).WithMany(p => p.Students)
                .HasForeignKey(d => d.Departmentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENTS_DEPT");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("SYS_C008230");

            entity.ToTable("USERS");

            entity.HasIndex(e => e.Username, "SYS_C008231").IsUnique();

            entity.HasIndex(e => e.Email, "SYS_C008232").IsUnique();

            entity.Property(e => e.Userid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORDHASH");
            entity.Property(e => e.Roleid)
                .HasColumnType("NUMBER")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USERS_ROLE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
