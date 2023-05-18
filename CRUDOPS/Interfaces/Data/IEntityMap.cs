using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CRUDOPS.Interfaces.Data
{
    public interface IEntityMap
    {
        void AddEntityMap(ModelBuilder modelBuilder);
    }
}
