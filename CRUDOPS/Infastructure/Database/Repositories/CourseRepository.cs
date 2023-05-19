using CRUDOPS.Infastructure.Database.Models;
using CRUDOPS.Interfaces.Data;
using CRUDOPS.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUDOPS.Infastructure.Database.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(CrudOpsDbContext databaseContext) : base(databaseContext)
        {
        }

    }
}
