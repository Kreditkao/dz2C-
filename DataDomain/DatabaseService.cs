using Microsoft.Data.SqlClient;
using Dapper;

namespace DataDomain;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void CreateUser(User user)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Execute("INSERT INTO Users (Name) VALUES (@Name)", user);
    }

    public User? GetUser(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        return connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });
    }

    public void UpdateUser(User user)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Execute("UPDATE Users SET Name = @Name WHERE Id = @Id", user);
    }

    public void DeleteUser(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Execute("DELETE FROM Users WHERE Id = @Id", new { Id = id });
    }
}
