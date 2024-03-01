using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Npgsql;
using Microsoft.AspNetCore.Builder;

namespace newspaper.shared.integrationTest;

public class Startup
{
    private readonly IConfiguration _configuguration;

    public Startup(IConfiguration configuration)
    {
        _configuguration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(DbHelper.ConnectionString));
        
        var connection = new NpgsqlConnection(DbHelper.ConnectionString);

        var cleansingSql = _configuguration.GetSection("cleansingScript").Get<string[]>();
        var seedSql = _configuguration.GetSection("seedScript").Get<string[]>();

        var sqlScript = cleansingSql.Union(seedSql);
        DbHelper.InitDB(connection, sqlScript);
    }

    public void Configure(IApplicationBuilder app, IServiceProvider services) { }
}

