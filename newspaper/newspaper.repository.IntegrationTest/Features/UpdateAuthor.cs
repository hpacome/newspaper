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
public class UpdateAuthor
{
    private readonly TestServer _factory;

    public UpdateAuthor(SetupFixture fixture)
    {
        _factory = fixture.Factory;
    }

    [Fact]
    public async Task TestMethod_UpdateMethode_ReturnsExpectedDataFromSqlSelect()
    {
        using var serviceScope = _factory.Services.CreateScope();
        var authorRepository = serviceScope.ServiceProvider.GetRequiredService<IAuthorRepository>();

        var expectedName = $"{DbData.Author103Name}_updated";
        var expectedEmail = $"{DbData.Author103Email}_updated";
        var author = new Author(DbData.Author104Id, expectedName, expectedEmail);
        await authorRepository.Update(author);

        var dbConnection = new NpgsqlConnection(DbHelper.ConnectionString);
        var query = $"SELECT * FROM t_author WHERE Id = '{DbData.Author104Id}'";
        var data = await dbConnection.QueryFirstOrDefaultAsync<Author>(query);

        Assert.NotNull(data);
        Assert.Equal(data!.Id, DbData.Author104Id);
        Assert.Equal(data!.Name, expectedName);
        Assert.Equal(data!.Email, expectedEmail);
    }
}
