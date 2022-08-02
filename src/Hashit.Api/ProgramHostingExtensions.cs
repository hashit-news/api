using Microsoft.EntityFrameworkCore;

public static class ProgramHostingExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment
    )
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var enableSensitiveDataLogging = !environment.IsProduction();
        var enableDetailedErrors = !environment.IsProduction();

        services.AddDbContext<HashitDbContext>(
            HashitDbContext.ConfigureDefaultOptions(
                connectionString,
                enableSensitiveDataLogging,
                enableDetailedErrors
            )
        );

        return services;
    }
}
