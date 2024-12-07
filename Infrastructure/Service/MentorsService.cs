using Dapper;
using Infrastructure.DataContext;
using Infrastructure.Models;
using Npgsql;

namespace Infrastructure.Service;
using Infrastructure.Interfaces;

public class MentorsService :IMentorsService
{
    private readonly DapperContext context;

    public MentorsService()
    {
        context = new DapperContext();
    }
    public bool DeleteMentor(int id)
    {
        try
        {
                string cmd = "Delete from Mentors where id = @id";
                var result = context.Connection().Execute(cmd, new { Id = id });
                return result > 0;
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
                string cmd = "Update Mentors set mentor_name = @mentor_name,email = @email,course_id = @course_id where id = @id";
                var result = context.Connection().Execute(cmd, mentor);
                return result > 0;
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
                string cmd =
                    "Insert into Mentors(mentor_name,email.course_id) values (mentor_name = @mentor_name,email = @email,course_id = @course_id)";
                var result = context.Connection().Execute(cmd, mentor);
                return result > 0;
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
                string cmd = "SELECT * FROM Mentors";
                List<Mentors> result = context.Connection().Query<Mentors>(cmd).ToList();
                return result;
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
                string cmd = "select * from Mentors where mentor_id = @mentor_id";
                Mentors result = context.Connection().QueryFirstOrDefault<Mentors>(cmd, new { id = id });
                return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}