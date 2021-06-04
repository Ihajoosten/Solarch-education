using Microsoft.EntityFrameworkCore;
using ModuleManagementEventHandler.Model;

namespace Pitstop.WorkshopManagementEventHandler.DataAccess
{
    public class ModuleManagementDBContext : DbContext
    {
        public ModuleManagementDBContext()
        { }

        public ModuleManagementDBContext(DbContextOptions<ModuleManagementDBContext> options) : base(options)
        { }

        public DbSet<Class> Class { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Lecture> Lecture { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Class>().HasKey(entity => entity.ClassId);
            builder.Entity<Class>().ToTable("Class");

            builder.Entity<Course>().HasKey(entity => entity.CourseId);
            builder.Entity<Course>().ToTable("Course");

            builder.Entity<Exam>().HasKey(entity => entity.ExamId);
            builder.Entity<Exam>().ToTable("Exam");

            builder.Entity<Lecture>().HasKey(entity => entity.LectureId);
            builder.Entity<Lecture>().ToTable("Lecture");

            builder.Entity<Module>().HasKey(entity => entity.ModuleId);
            builder.Entity<Module>().ToTable("Module");

            builder.Entity<Student>().HasKey(entity => entity.StudentId);
            builder.Entity<Student>().ToTable("Student");

            builder.Entity<Teacher>().HasKey(entity => entity.TeacherId);
            builder.Entity<Teacher>().ToTable("Teacher");

            base.OnModelCreating(builder);
        }
    }
}
