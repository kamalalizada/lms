using Entity.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Entrollment> Enrollments { get; set; }
    }
}


