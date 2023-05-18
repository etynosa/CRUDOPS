using CRUDOPS.Interfaces.Data;

namespace CRUDOPS.Infastructure.Database.Models
{
    public class Course : IEntity 
    {
        public long Id { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
    }
}
