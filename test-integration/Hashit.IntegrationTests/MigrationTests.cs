using Microsoft.EntityFrameworkCore;

public sealed class MigrationTests
{
    [Fact]
    public async Task CanMigrateDatabase()
    {
        // arrange
        var dbName = $"hashit-test-{Guid.NewGuid()}";
        var connectionString =
            $"Host=localhost;Username=postgres;Password=hashit;Database={dbName}";
        var options = HashitDbContext.GetDefaultOptions(connectionString, true, true);
        var db = new HashitDbContext(options);

        // act
        var pendingMigrations = await db.Database.GetPendingMigrationsAsync();
        await db.Database.MigrateAsync();
        var appliedMigrations = await db.Database.GetAppliedMigrationsAsync();

        // assert
        // created.Should().BeTrue();
        pendingMigrations.Should().NotBeEmpty();
        appliedMigrations.Should().NotBeEmpty();
        pendingMigrations.Should().BeEquivalentTo(appliedMigrations);

        // cleanup
        await db.Database.EnsureDeletedAsync();
    }
}
