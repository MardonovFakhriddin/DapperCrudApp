using Infrastructure.Models;
using Npgsql;
using Dapper;
namespace Infrastructure.Service;
using Infrastructure.Interfaces;

public class StudentsService:IStudentsService
{
    string connectionString = "Server=localhost; port = 5432; Database = dappercruddb; username = postgres; password = LMard1909";

    public bool DeleteStudent(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string cmd = "Delete from students where id = @id";
                var result = connection.Execute(cmd, new { Id = id });
                return result > 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateStudent(Students student)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            string cmd =
                "update students set strudent_name = @student_name, email = @email,group_id = @group_id,course_id = @course_id";
            var result = connection.Execute(cmd, student);
            return result > 0;
        }
    }

    public bool InsertStudent(Students student)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            string cmd =
                "Insert into Students (student_name, email, group_id.course_id) values (strudent_name=@student_name, email = @email, group_id = @group_id,course_id = @course_id)";
            var result = connection.Execute(cmd, student);
            return result > 0;
        }
    }

    public List<Students> GetStudents()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string cmd = "select * from students";
                List<Students> result = connection.Query<Students>(cmd).ToList();
                return result;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Students GetStudentById(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            string cmd = "select * from students where student_id = @student_id";
            Students result = connection.QuerySingleOrDefault<Students>(cmd, new { Id = id });
            return result;
        }
    }
}