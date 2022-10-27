using Microsoft.EntityFrameworkCore;
using OG.GraphQL.Domain.Entities;


namespace OG.GraphQL.Infrastructure.Contexts
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext() { }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<OfficeAssignment> OfficeAssignments { get; set; } = null!;
        public virtual DbSet<OnlineCourse> OnlineCourses { get; set; } = null!;
        public virtual DbSet<OnsiteCourse> OnsiteCourses { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<StudentGrade> StudentGrades { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).ValueGeneratedNever();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Department");

                entity.HasMany(d => d.People)
                    .WithMany(p => p.Courses)
                    .UsingEntity<Dictionary<string, object>>(
                        "CourseInstructor",
                        l => l.HasOne<Person>().WithMany().HasForeignKey("PersonId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CourseInstructor_Person"),
                        r => r.HasOne<Course>().WithMany().HasForeignKey("CourseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CourseInstructor_Course"),
                        j =>
                        {
                            j.HasKey("CourseId", "PersonId");

                            j.ToTable("CourseInstructor");

                            j.IndexerProperty<int>("CourseId").HasColumnName("CourseID");

                            j.IndexerProperty<int>("PersonId").HasColumnName("PersonID");
                        });
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).ValueGeneratedNever();
            });

            modelBuilder.Entity<OfficeAssignment>(entity =>
            {
                entity.Property(e => e.InstructorId).ValueGeneratedNever();

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Instructor)
                    .WithOne(p => p.OfficeAssignment)
                    .HasForeignKey<OfficeAssignment>(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfficeAssignment_Person");
            });

            modelBuilder.Entity<OnlineCourse>(entity =>
            {
                entity.Property(e => e.CourseId).ValueGeneratedNever();

                entity.HasOne(d => d.Course)
                    .WithOne(p => p.OnlineCourse)
                    .HasForeignKey<OnlineCourse>(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineCourse_Course");
            });

            modelBuilder.Entity<OnsiteCourse>(entity =>
            {
                entity.Property(e => e.CourseId).ValueGeneratedNever();

                entity.HasOne(d => d.Course)
                    .WithOne(p => p.OnsiteCourse)
                    .HasForeignKey<OnsiteCourse>(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnsiteCourse_Course");
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Student");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
