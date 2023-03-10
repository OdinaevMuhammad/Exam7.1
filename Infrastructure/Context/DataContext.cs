namespace Infrastructure.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ClassroomStudent>()
                .HasKey(t => new { t.StudentId, t.ClassroomId });

        modelBuilder.Entity<ClassroomStudent>()
            .HasOne(sc => sc.Student)
            .WithMany(s => s.ClassroomStudents)
            .HasForeignKey(sc => sc.StudentId);

        modelBuilder.Entity<ClassroomStudent>()
            .HasOne(sc => sc.Classroom)
            .WithMany(c => c.ClassroomStudents);




    }

    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<ClassroomStudent> ClassroomStudents { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Issues> Issues { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TimeTable> TimeTables { get; set; }

}