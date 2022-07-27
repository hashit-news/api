using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using Serilog.Events;

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

    builder.Services.AddCors();

    builder.Services.AddHttpContextAccessor();

    var app = builder.Build();

    app.UseHttpLogging();

    app.UseCors();

    app.Run();

    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");

    return 1;
}
finally
{
    Log.CloseAndFlush();
}
