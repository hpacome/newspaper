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
public class CreateAuthor
{
    private readonly TestServer _factory;

    public CreateAuthor(SetupFixture fixture)
    {
        _factory = fixture.Factory;
    }

    [Fact]
    public async Task TestMethod_CreateMethode_ReturnsExpectedDataFromSqlSelect()
    {
        using var serviceScope = _factory.Services.CreateScope();
        var authorRepository = serviceScope.ServiceProvider.GetRequiredService<IAuthorRepository>();

        var author = DbData.Author101;
        await authorRepository.Create(author);

        var dbConnection = new NpgsqlConnection(DbHelper.ConnectionString);
        var query = $"SELECT * FROM t_author WHERE Id = '{DbData.Author101Id}'";
        var data = await dbConnection.QueryFirstOrDefaultAsync<Author>(query);

        Assert.NotNull(data);
        Assert.Equal(data!.Id, DbData.Author101Id);
        Assert.Equal(data!.Name, DbData.Author101Name);
        Assert.Equal(data!.Email, DbData.Author101Email);
    }
}
