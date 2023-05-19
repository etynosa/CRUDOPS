using CRUDOPS.Infastructure.Database.Models;
using CRUDOPS.Interfaces.Repositories;

namespace CRUDOPS.Infastructure.Database.Repositories
{
    public class StudentCoursesRepository : Repository<StudentCourses>, IStudentCoursesRepository
    {
        public StudentCoursesRepository(CrudOpsDbContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
