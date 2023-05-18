using CRUDOPS.Interfaces.Data;

namespace CRUDOPS.Infastructure.Database.Models
{
    public class Grade : IEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
