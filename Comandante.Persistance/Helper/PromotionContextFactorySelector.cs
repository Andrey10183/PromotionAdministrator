using Comandante.App;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Comandante.Persistance.Helper;

public interface IPromotionContextFactorySelector
{
    IDbContextFactory<PromotionContext> GetFactory(bool readOnly);
}

public class PromotionContextFactorySelector : IPromotionContextFactorySelector
{
    private readonly IConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;

    public PromotionContextFactorySelector(
        IConfiguration configuration, 
        IServiceProvider serviceProvider)
    {
        _configuration = configuration;
        _serviceProvider = serviceProvider;
    }

    public IDbContextFactory<PromotionContext> GetFactory(bool readOnly)
    {
        var connectionString = readOnly ? 
            _configuration.GetConnectionString("Database") : 
            _configuration.GetConnectionString("DatabaseReadOnly");

        var options = new DbContextOptionsBuilder<PromotionContext>()
            .UseSqlServer(connectionString)
            .Options;

        return new DbContextFactory<PromotionContext>(
            serviceProvider: _serviceProvider,
            options: options,
            factorySource: new DbContextFactorySource<PromotionContext>());
    }
}
