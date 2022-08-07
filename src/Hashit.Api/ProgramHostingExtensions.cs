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

    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        services.Scan(
            scan =>
                scan.FromAssemblyOf<Entity>()
                    .AddClasses(classes => classes.AssignableTo(typeof(IUserDomainService)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
        );

        return services;
    }

    public static IServiceCollection AddDataLayer(this IServiceCollection services)
    {
        services.Scan(
            scan =>
                scan.FromAssemblyOf<HashitDbContext>()
                    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
        );

        return services;
    }

    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddSingleton<IKeyGenerator, KeyGenerator>();

        return services;
    }
}
