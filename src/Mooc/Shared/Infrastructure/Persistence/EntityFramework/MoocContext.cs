namespace CodelyTv.Mooc.Shared.Infrastructure.Persistence.EntityFramework
{
    using Courses.Domain;
    using CoursesCounter.Domain;
    using EntityConfigurations;
    using Microsoft.EntityFrameworkCore;

    public class MoocContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CoursesCounter> CoursesCounter { get; set; }

        public MoocContext(DbContextOptions<MoocContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CoursesCounterConfiguration());
        }
    }
}