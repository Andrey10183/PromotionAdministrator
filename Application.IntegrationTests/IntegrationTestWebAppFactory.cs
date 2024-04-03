using Comandante.Persistance.Helper;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using Testcontainers.MsSql;

namespace Application.IntegrationTests;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private const string Database = "Promotion";

    private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
        .WithName("Test-promotion")
        .Build();
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            //take connection string from test container
            var cs = _dbContainer.GetConnectionString();

            //find descriptor of DbFactorySelector
            var descriptor = services
                .SingleOrDefault(s => 
                    s.ServiceType == typeof(IPromotionContextFactorySelector));

            //Remove it
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            //Substitute by test dbSelector implementation
            services.AddScoped<IPromotionContextFactorySelector, TestPromotionContextSelector>(x => 
                new TestPromotionContextSelector(cs, x.GetRequiredService<IServiceProvider>()));
        });
    }

    public async Task InitializeAsync()
    {
       await  _dbContainer.StartAsync();

       await MigrationHelper.CreateMigration(_dbContainer, Database);
    }

    public new Task DisposeAsync()
    {
        return _dbContainer.StopAsync();
    }
}

public sealed class DbConnectionFactory
{
    private readonly IDatabaseContainer _databaseContainer;

    private readonly string _database;

    public DbConnectionFactory(IDatabaseContainer databaseContainer, string database)
    {
        _databaseContainer = databaseContainer;
        _database = database;
    }

    public DbConnection MasterDbConnection => 
        new SqlConnection(_databaseContainer.GetConnectionString());

    public DbConnection CustomDbConnection
    {
        get
        {
            var connectionString = new SqlConnectionStringBuilder(_databaseContainer.GetConnectionString());
            connectionString.InitialCatalog = _database;
            return new SqlConnection(connectionString.ToString());
        }
    }
}