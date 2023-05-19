using CRUDOPS.Infastructure.Database.Models;
using CRUDOPS.Interfaces.Repositories;

namespace CRUDOPS.Infastructure.Database.Repositories
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        public GradeRepository(CrudOpsDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
