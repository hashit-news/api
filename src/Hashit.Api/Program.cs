using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using Serilog.Events;
using System.Reflection;

Log.Logger = new LoggerConfiguration().MinimumLevel
    .Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting web host");

    var builder = WebApplication.CreateBuilder(args);

    // setup serilog logging provider
    builder.Host.UseSerilog(
        (context, services, config) =>
        {
            config.ReadFrom.Configuration(context.Configuration);
            config.ReadFrom.Services(services);
        }
    );

    builder.Services.AddHttpLogging(x =>
    {
        x.LoggingFields = builder.Environment.IsProduction()
            ? HttpLoggingFields.RequestPropertiesAndHeaders
                | HttpLoggingFields.ResponsePropertiesAndHeaders
                | HttpLoggingFields.RequestQuery
            : HttpLoggingFields.All;
    });

    builder.Services.AddHealthChecks();

    builder.Services.AddCors();

    builder.Services.AddHttpContextAccessor();

    builder.Services.AddDatabase(builder.Configuration, builder.Environment);

    builder.Services.AddRouting(options =>
    {
        options.LowercaseUrls = true;
    });

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(options =>
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

    builder.Services.AddInfrastructureLayer();
    builder.Services.AddDomainLayer();

    var app = builder.Build();

    app.UseHttpLogging();

    app.UseCors();

    app.UseMiddleware<RequestIdMiddleware>();

    app.UseHealthChecks(Routes.HealthChecks);

    if (!builder.Environment.IsProduction())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint(Routes.SwaggerDocument, "Hashit API");
        });
    }

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();

    return 0;
}
catch (Exception ex)
{
    // For silencing EF Core's migration termination error log which is expected.
    // https://stackoverflow.com/a/70256808
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
    {
        throw;
    }

    Log.Fatal(ex, "Host terminated unexpectedly");

    return 1;
}
finally
{
    Log.CloseAndFlush();
}

// Used for integration testing.
// https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0#sut-environment
public partial class Program { }
