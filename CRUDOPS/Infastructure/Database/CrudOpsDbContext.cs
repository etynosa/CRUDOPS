using CRUDOPS.DomainModels;
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
        public DbSet<User> Users { get; set; }
        public DbSet<UserResponse> UserResponse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=crudops.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserResponse>().HasNoKey();

        }

    }
}
