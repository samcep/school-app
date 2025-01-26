using Microsoft.EntityFrameworkCore;
using school_app.Entities;

namespace school_app
{
    public class ApplicationDbConext : DbContext 
    {

        public ApplicationDbConext(DbContextOptions<ApplicationDbConext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().Property(course => course.Description).HasMaxLength(250);
            modelBuilder.Entity<Course>().Property(course => course.MaxStudents).HasDefaultValue(0);
            modelBuilder.Entity<Enrollment>().HasKey(enrollments => new { enrollments.StudentId, enrollments.CourseId });
            modelBuilder.Entity<Course>().Property(course => course.Name).HasField("_name");

        }

        public DbSet<Course> courses { get; set; }
        public DbSet<Student> students { get; set; } 
        public DbSet<Enrollment> enrollments { get; set; }
}
}
