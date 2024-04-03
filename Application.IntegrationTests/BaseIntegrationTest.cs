using Comandante.App;
using Comandante.Persistance.Helper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    private readonly IServiceScope _scope;
    protected readonly ISender Sender;
    protected readonly PromotionContext DbContext;
    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();

        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        
        var contextFactorySelector = _scope.ServiceProvider
            .GetRequiredService<IPromotionContextFactorySelector>();

        var dbFactory = contextFactorySelector.GetFactory(false);

        DbContext = dbFactory.CreateDbContext();
    }
}
