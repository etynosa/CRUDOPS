using CRUDOPS.Interfaces.Data;

namespace CRUDOPS.Infastructure.Database.Models
{
    public class Student: IEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
