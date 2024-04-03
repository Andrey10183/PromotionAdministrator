using Comandante.App;
using Comandante.App.Services;
using Comandante.Application.Behaviors;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region ServiceRegistration

AppVersion.Version = System.Reflection.Assembly
    .GetEntryAssembly()?
    .GetName()
    .Version;

AppVersion.Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

//Add serilog configuration via Appsettings
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddMudServices();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient("MailService",client => 
    client.BaseAddress = new Uri(builder.Configuration.GetSection("ServicesEndpoints:MailService")?.Value ??
                                           throw new Exception("Email service base address not provided!")));

//Add Ui helper services
builder.Services.AddScoped<SenderService>();
builder.Services.AddScoped<SnackBarService>();

//AuthenticationServices registration
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationService>();

builder.Services.AddCascadingAuthenticationState();

var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddDbContext<PromotionContext>(options =>
{
    options.UseSqlServer(connectionString, b => {
        b.MigrationsAssembly("Comandante.App");
    });
});

//Scan available services via it's implemented interfaces
builder
    .Services
    .Scan(
        selector => selector
            .FromAssemblies(
                Comandante.Persistance.AssemblyReference.Assembly,
                Comandante.Infrastructure.AssemblyReference.Assembly)
            .AddClasses(false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

#region Behavior registration
//Registration order important!
//Register logging handling
builder.Services.AddScoped(
    typeof(IPipelineBehavior<,>),
    typeof(LoggingPipelineBehavior<,>));

//Register Validation handling services
builder.Services.AddScoped(
    typeof(IPipelineBehavior<,>), 
    typeof(ValidationPipelineBehavior<,>));

builder.Services.AddTransient(
    typeof(IRequestExceptionHandler<,,>),
    typeof(ExceptionPipelineBehavior<,,>));

#endregion

builder.Services.AddValidatorsFromAssembly(
    Comandante.Application.AssemblyReference.Assembly,
    includeInternalTypes: true);

//Register MediatR library - for implementing CQRS pattern
builder.Services.AddMediatR(cfg => cfg
    .RegisterServicesFromAssembly(Comandante.Application.AssemblyReference.Assembly));

#endregion

var app = builder.Build();

#region MiddlwareSetup

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

#endregion

#region start app

try
{
    //var connectionString = builder.Configuration.GetConnectionString("Database");
    var connectedBase = connectionString?.Split(';').FirstOrDefault();
    Log.Information("Staring Comandante App");
    Log.Information($"Environment:{AppVersion.Environment}");
    Log.Information($"Ver. {AppVersion.Version?.ToString()}");
    Log.Information($"Connected database: {connectedBase}");
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("==========================");
    Console.WriteLine(ex.Message, "Comandante Terminated Unexpectedly");
    Log.Fatal(ex, "Comandante Terminated Unexpectedly");
}

finally
{
    Log.CloseAndFlush();
}

#endregion

public partial class Program{}
