using Dapper;
using Infrastructure.Models;
using Npgsql;

namespace Infrastructure.Service;
using Infrastructure.Interfaces;

public class MentorsService :IMentorsService
{
    private string connectionString =
        "Server=localhost; port = 5432; Database = dappercruddb; username = postgres; password = LMard1909";
    
    public bool DeleteMentor(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string cmd = "Delete from Mentors where id = @id";
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

    public bool UpdateMentor(Mentors mentor)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string cmd = "Update Mentors set mentor_name = @mentor_name,email = @email,course_id = @course_id where id = @id";
                var result = connection.Execute(cmd, mentor);
                return result > 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool InsertMentor(Mentors mentor)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string cmd =
                    "Insert into Mentors(mentor_name,email.course_id) values (mentor_name = @mentor_name,email = @email,course_id = @course_id)";
                var result = connection.Execute(cmd, mentor);
                return result > 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Mentors> GetMentors()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string cmd = "SELECT * FROM Mentors";
                List<Mentors> result = connection.Query<Mentors>(cmd).ToList();
                return result;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Mentors GetMentorById(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string cmd = "select * from Mentors where mentor_id = @mentor_id";
                Mentors result = connection.QueryFirstOrDefault<Mentors>(cmd, new { id = id });
                return result;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}