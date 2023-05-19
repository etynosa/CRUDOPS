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

        //protected override void onModelCreating(ModelBuilder modelBuilder) 
        //{
        //    modelBuilder.Entity<Course>().HasData(
        //        new Course { CourseCode = 1, CourseName= "Mathematics", CourseTitle="Calculations" },
        //        new Course { CourseCode = 2, CourseName = "Physics", CourseTitle = "Electromagnetics" },
        //        new Course { CourseCode = 3, CourseName = "Chemistry", CourseTitle = "Organic" }
        //        );
        //}
    }
}
