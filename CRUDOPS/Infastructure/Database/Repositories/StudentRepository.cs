using CRUDOPS.Infastructure.Database.Models;
using CRUDOPS.Interfaces.Repositories;

namespace CRUDOPS.Infastructure.Database.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(CrudOpsDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
