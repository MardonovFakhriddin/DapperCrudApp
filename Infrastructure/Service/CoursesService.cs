using Dapper;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Npgsql;

namespace Infrastructure.Service;

public class CoursesService :ICoursesService
{
    string connectionString = "Server=localhost; port = 5432; Database = dappercruddb; username = postgres; password = LMard1909";
    public bool DeleteCourse(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new  NpgsqlConnection(connectionString))
            {
                string cmd = "Delete from Corses where id = @id";
                var affected = connection.Execute(cmd,new {Id = id});
                return affected > 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateCourse(Courses course)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string cmd = "Update Courses set course_Name = @course_Name, description = @description where id = @id";
                var affected = connection.Execute(cmd, course);
                return affected > 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool InsertCourse(Courses course)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string cmd = "Insert into courses(course_id,course_name,description) values (@id,@name,@description) ";
                var affected = connection.Execute(cmd, course);
                return affected > 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Courses> GetCourses()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string cmd = "Select * from courses";
                List<Courses> courses = connection.Query<Courses>(cmd).ToList();
                return courses;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Courses GetCourseById(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string cmd = "Select * from courses where id = @id";
                Courses courses = connection.QuerySingleOrDefault<Courses>(cmd, new { Id = @id });
                return courses;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}