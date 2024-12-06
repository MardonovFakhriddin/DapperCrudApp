using Dapper;
using Infrastructure.Models;
using Npgsql;

namespace Infrastructure.Service;
using Infrastructure.Interfaces;

public class GroupsService : IGroupsService
{
    private string connectionString = "Server=localhost; port = 5432; Database = dappercruddb; username = postgres; password = LMard1909";

    
    public bool DeleteGroup(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                var cmd = "Delete from Groups where id = @id";
                var result = connection.Execute(cmd, new { Id = @id });
                return result > 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateGroup(Groups group)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                var cmd = "UPDATE Groups SET group_name = @group_name WHERE id = @Id";
                var result = connection.Execute(cmd, group);
                return result > 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool InsertGroup(Groups group)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                var cmd = "INSERT INTO Groups (group_id,group_name, course_id) VALUES (@group_id,@group_name, @course_id)";
                var result = connection.Execute(cmd, group);
                return result > 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Groups> Groups()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                var cmd = "Select * from Groups";
                List<Groups> groups = connection.Query<Groups>(cmd).ToList();
                return groups;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Groups GetGroupById(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string cmd = "SELECT * FROM Groups WHERE id = @id";
                Groups groups = connection.QuerySingleOrDefault<Groups>(cmd, new { Id = @id });
                return groups;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}