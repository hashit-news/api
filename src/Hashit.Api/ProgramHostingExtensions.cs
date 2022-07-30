using Microsoft.EntityFrameworkCore;

public static class ProgramHostingExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment
    )
    {
        services.AddDbContext<HashitDbContext>(options =>
        {
            options
                .UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    o =>
                    {
                        o.UseNodaTime();
                        o.MigrationsAssembly(typeof(Entity).Assembly.GetName().Name);
                    }
                )
                .UseSnakeCaseNamingConvention();

            if (!environment.IsProduction())
            {
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            }
        });

        return services;
    }
}
