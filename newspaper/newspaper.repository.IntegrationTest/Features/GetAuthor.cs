using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using newspaper.repository.Abstraction;
using System.Threading.Tasks;
using Xunit;

namespace newspaper.repository.IntegrationTest.Features;

[Collection("author")]
public class GetAuthor
{
    private readonly TestServer _factory;

    public GetAuthor(SetupFixture fixture)
    {
        _factory = fixture.Factory;
    }

    [Fact]
    public async Task TestMethod_GetByIdMethode_ResultEqualsExpectedData()
    {
        using var serviceScope = _factory.Services.CreateScope();
        var authorRepository = serviceScope.ServiceProvider.GetRequiredService<IAuthorRepository>();

        var author = DbData.Author103;
        var result = await authorRepository.GetById(author.Id);

        Assert.NotNull(result);
        Assert.Equal(result!.Id, DbData.Author103Id);
        Assert.Equal(result!.Name, DbData.Author103Name);
        Assert.Equal(result!.Email, DbData.Author103Email);
    }
}
