using CRUDOPS.Interfaces.Data;

namespace CRUDOPS.Infastructure.Database.Models
{
    public class StudentCourses :  IEntity
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long CourseId { get; set; }
        public long GradeId { get; set; }

    }
}
