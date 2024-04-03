using Comandante.App;
using Comandante.Persistance.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Application.IntegrationTests;

/// <summary>
/// Test Promotion context selector implementation
/// For test purposes only
/// </summary>
public class TestPromotionContextSelector : IPromotionContextFactorySelector
{
    private readonly string _connectionString;
    private readonly IServiceProvider _serviceProvider;

    public TestPromotionContextSelector(string connectionString, IServiceProvider serviceProvider)
    {
        _connectionString = connectionString;
        _serviceProvider = serviceProvider;
    }

    public IDbContextFactory<PromotionContext> GetFactory(bool readOnly)
    {
        var options = new DbContextOptionsBuilder<PromotionContext>()
            .UseSqlServer(_connectionString)
            .Options;

        return new DbContextFactory<PromotionContext>(
            serviceProvider: _serviceProvider,
            options: options,
            factorySource: new DbContextFactorySource<PromotionContext>());
    }
}