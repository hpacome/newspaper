using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using newspaper.repository.Abstraction;
using newspaper.shared.integrationTest;
using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace newspaper.repository.IntegrationTest;

public class SetupFixture : IDisposable
{
    public TestServer Factory { get; set; }

    public SetupFixture()
    {
        Factory = new TestServer(new WebHostBuilder()
            .ConfigureServices((services) =>
            {
                services.AddScoped<IAuthorRepository, AuthorRepository>();
            })
            .ConfigureAppConfiguration((_, builder) =>
            {
                var cleansingSql = DbData.GetCleansingSql();
                builder.AddInMemoryCollection(cleansingSql);
                var seedSql = DbData.GetSeedSql();
                builder.AddInMemoryCollection(seedSql);
            })
            .UseStartup<Startup>());
    }

    public void Dispose()
    {
        Factory.Dispose();
        GC.SuppressFinalize(this);
    }
}

[CollectionDefinition("author")]
public class SetupCollectionFixture : ICollectionFixture<SetupFixture>
{

}
