# CRUDOPS Project

This is a .NET MVC application that demonstrates CRUD (Create, Read, Update, Delete) operations with sorting, filtering, and pagination. It also includes logging to the console, consuming the Randomuser API, and interacting with a public API.

## Project Structure

The project follows a standard MVC (Model-View-Controller) architecture. Here's an overview of the project structure:

- `Controllers/`: Contains the MVC controllers, including the `StudentController`.
- `Models/`: Defines the entity models, such as `Student`, `Course`, `Grade`, and `StudentCourses`.
- `Repositories/`: Implements the repository pattern for data access, including the generic `Repository` class.
- `Services/`: Contains the business logic services, including the `StudentService`.
- `Infrastructure/`: Contains additional infrastructure-related classes, such as the `RandomUserApiClient` for consuming the Randomuser API.
- `Views/`: Contains the Razor views for rendering the UI.
- `Startup.cs`: Configures the application and sets up dependency injection.

## Setup and Configuration

1. Clone the repository to your local machine.

2. Open the project in your preferred development environment (e.g., Visual Studio).

3. Update the database connection string in the `appsettings.json` file to point to your database.

4. Run the database migrations to create the required tables.

5. Build and run the application.

## Functionality

The application provides the following functionality:

- CRUD operations for managing students, courses, grades, and student-course relationships.
- Sorting, filtering, and pagination for better data organization and retrieval.
- Logging to the console to track important events and operations.
- Integration with the Randomuser API to fetch random student data.
- Interaction with other public APIs (provide details of the specific APIs integrated).

## Usage

Once the application is running, you can access the different functionality through the provided UI. Here are some key actions you can take:

- Manage Students: Create, update, and delete student records. View a list of all students with sorting, filtering, and pagination options.

- Manage Courses: Create, update, and delete course records. View a list of all courses with sorting, filtering, and pagination options.

- Manage Grades: Create, update, and delete grade records. View a list of all grades with sorting, filtering, and pagination options.

- Manage Student Courses: Create, update, and delete student-course relationships. View a list of all student-course relationships with sorting, filtering, and pagination options.

## Dependencies

The project relies on the following dependencies:

- ASP.NET MVC: The framework for building web applications.
- Entity Framework Core: An ORM for database access and management.
- Newtonsoft.Json: A popular JSON library for deserializing API responses.
- Other dependencies (list any additional dependencies used in your project).

Make sure to restore the NuGet packages and update them if necessary.

## License


Feel free to customize this README file with any additional information specific to your project. Good luck with your development!
