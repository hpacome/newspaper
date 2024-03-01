using Dapper;
using newspaper.repository.Abstraction;
using newspaper.repository.Entities;
using System.Data;

namespace newspaper.repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly IDbConnection _dbConnection;

    public AuthorRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task Create(Author entity)
    {
        var query = "INSERT INTO t_author (id, name, email) VALUES (@id, @name, @email)";

        var parameters = new DynamicParameters();
        parameters.Add("id", entity.Id, DbType.Guid);
        parameters.Add("name", entity.Name, DbType.String);
        parameters.Add("email", entity.Email, DbType.String);

        await _dbConnection.ExecuteAsync(query, parameters);
    }

    public async Task<bool> Delete(Guid id)
    {
        var query = "DELETE FROM t_author WHERE id = @id";

        var result = await _dbConnection.ExecuteAsync(query, new { id });
        return result > 0;
    }

    public async Task<Author?> GetById(Guid id)
    {
        var query = "SELECT * FROM t_author WHERE Id = @id";

        var parameters = new DynamicParameters();
        parameters.Add("id", id, DbType.Guid);

        var entity = await _dbConnection.QueryFirstOrDefaultAsync<Author>(query, parameters);
        return entity;
    }

    public async Task Update(Author entity)
    {
        var query = "UPDATE t_author SET name = @name, email = @email WHERE id = @id";

        var parameters = new DynamicParameters();
        parameters.Add("id", entity.Id, DbType.Guid);
        parameters.Add("name", entity.Name, DbType.String);
        parameters.Add("email", entity.Email, DbType.String);

        await _dbConnection.ExecuteAsync(query, parameters);
    }
}
