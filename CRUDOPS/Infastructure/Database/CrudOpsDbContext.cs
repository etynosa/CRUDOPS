using CRUDOPS.Infastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDOPS.Infastructure.Database
{
    public class CrudOpsDbContext : DbContext
    {
        public CrudOpsDbContext(DbContextOptions<CrudOpsDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }
    }
}
