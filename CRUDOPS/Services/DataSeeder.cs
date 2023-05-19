using Microsoft.Data.Sqlite;

namespace CRUDOPS.Services
{
    public class DataSeeder
    {
        private readonly string _connectionString;

        public DataSeeder(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SeedData()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Courses (CourseName, CourseCode, CourseTitle) VALUES " +
                        "('Course 1', 'CODE-001', 'Introduction to Programming'), " +
                        "('Course 2', 'CODE-002', 'Database Management'), " +
                        "('Course 3', 'CODE-003', 'Web Development'), " +
                        "('Course 4', 'CODE-004', 'Data Structures and Algorithms'), " +
                        "('Course 5', 'CODE-005', 'Software Engineering'), " +
                        "('Course 6', 'CODE-006', 'Artificial Intelligence'), " +
                        "('Course 7', 'CODE-007', 'Mobile App Development'), " +
                        "('Course 8', 'CODE-008', 'Network Security'), " +
                        "('Course 9', 'CODE-009', 'Cloud Computing'), " +
                        "('Course 10', 'CODE-010', 'Operating Systems');";

                    command.ExecuteNonQuery();

                    // Add more commands for seeding data into other tables

                    // Execute any other necessary SQL commands for data seeding
                }
            }
        }
    }
}
