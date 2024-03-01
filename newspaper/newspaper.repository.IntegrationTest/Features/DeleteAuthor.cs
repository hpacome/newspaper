using Dapper;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using newspaper.repository.Abstraction;
using newspaper.repository.Entities;
using newspaper.shared.integrationTest;
using Npgsql;
using System.Threading.Tasks;
using Xunit;

namespace newspaper.repository.IntegrationTest.Features;

[Collection("author")]
public class DeleteAuthor
{
    private readonly TestServer _factory;

    public DeleteAuthor(SetupFixture fixture)
    {
        _factory = fixture.Factory;
    }

    [Fact]
    public async Task TestMethod_DeleteMethode_DoesNotReturnDataFromSqlSelect()
    {
        using var serviceScope = _factory.Services.CreateScope();
        var authorRepository = serviceScope.ServiceProvider.GetRequiredService<IAuthorRepository>();

        var id = DbData.Author102.Id;
        await authorRepository.Delete(id);

        var dbConnection = new NpgsqlConnection(DbHelper.ConnectionString);
        var query = $"SELECT * FROM t_author WHERE Id = '{DbData.Author102Id}'";
        var data = await dbConnection.QueryFirstOrDefaultAsync<Author>(query);

        Assert.Null(data);
    }
}
