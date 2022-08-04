using Microsoft.EntityFrameworkCore;

/// <summary>
/// A collection fixture that is responsible for creating and dropping the database
/// https://xunit.net/docs/shared-context
/// </summary>
public class DbFixture : IDisposable
{
    private readonly HashitDbContext _db;
    private readonly string _dbName = $"hashit-test-{Guid.NewGuid()}";
    private readonly string _connectionString;

    public DbFixture()
    {
        _connectionString = $"Host=localhost;Username=root;Password=hashit;Database={_dbName}";

        var options = HashitDbContext.GetDefaultOptions(_connectionString, true, true);

        _db = new HashitDbContext(options);
        _db.Database.Migrate();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _db.Database.EnsureDeleted();
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
