using Infrastructure.Models;
using Npgsql;
using Dapper;
using Infrastructure.DataContext;

namespace Infrastructure.Service;
using Infrastructure.Interfaces;

public class StudentsService:IStudentsService
{
    private readonly DapperContext context;

    public StudentsService()
    {
        context = new DapperContext();
    }
    public bool DeleteStudent(int id)
    {
        try
        {
                string cmd = "Delete from students where id = @id";
                var result = context.Connection().Execute(cmd, new { Id = id });
                return result > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateStudent(Students student)
    {
            string cmd =
                "update students set strudent_name = @student_name, email = @email,group_id = @group_id,course_id = @course_id";
            var result = context.Connection().Execute(cmd, student);
            return result > 0;
    }

    public bool InsertStudent(Students student)
    {
            string cmd =
                "Insert into Students (student_name, email, group_id.course_id) values (strudent_name=@student_name, email = @email, group_id = @group_id,course_id = @course_id)";
            var result = context.Connection().Execute(cmd, student);
            return result > 0;
    }

    public List<Students> GetStudents()
    {
        try
        {
                string cmd = "select * from students";
                List<Students> result = context.Connection().Query<Students>(cmd).ToList();
                return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Students GetStudentById(int id)
    {
            string cmd = "select * from students where student_id = @student_id";
            Students result = context.Connection().QuerySingleOrDefault<Students>(cmd, new { Id = id });
            return result;
    }
}