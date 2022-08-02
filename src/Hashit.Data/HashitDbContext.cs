using Npgsql;

public class HashitDbContext : DbContext
{
    public HashitDbContext(DbContextOptions<HashitDbContext> options) : base(options) { }

    static HashitDbContext()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<RoleType>();
    }

    public static DbContextOptions<HashitDbContext> GetDefaultOptions(
        string connectionString,
        bool enableSensitiveDataLogging,
        bool enableDetailedErrors
    )
    {
        var optionsBuilder = new DbContextOptionsBuilder<HashitDbContext>();
        ConfigureDefaultOptions(connectionString, enableSensitiveDataLogging, enableDetailedErrors)(
            optionsBuilder
        );

        return optionsBuilder.Options;
    }

    public static Action<DbContextOptionsBuilder> ConfigureDefaultOptions(
        string connectionString,
        bool enableSensitiveDataLogging,
        bool enableDetailedErrors
    )
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException(
                $"'{nameof(connectionString)}' cannot be null or whitespace.",
                nameof(connectionString)
            );

        return options =>
        {
            options
                .UseNpgsql(
                    connectionString,
                    o =>
                    {
                        o.UseNodaTime();
                        o.MigrationsAssembly(typeof(Entity).Assembly.GetName().Name);
                        o.MigrationsHistoryTable("__migration_history");
                    }
                )
                .UseSnakeCaseNamingConvention();

            if (enableSensitiveDataLogging)
                options.EnableSensitiveDataLogging();

            if (enableDetailedErrors)
                options.EnableDetailedErrors();
        };
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<UserRole> UserRoles { get; set; } = null!;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<Entity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = SystemClock.Instance.GetCurrentInstant();
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = SystemClock.Instance.GetCurrentInstant();
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<RoleType>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<RoleType>();

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(EntityTypeConfigurationBase<>).Assembly
        );
    }
}
