/// <inheritdoc/>
public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly HashitDbContext _db;

    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{T}"/> class.
    /// </summary>
    /// <param name="db"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public Repository(HashitDbContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    /// <inheritdoc/>
    public IUnitOfWork UnitOfWork => _db;

    protected HashitDbContext Db => _db;

    /// <inheritdoc/>
    public async Task Insert(T entity, CancellationToken cancellationToken = default)
    {
        await _db.Set<T>().AddAsync(entity, cancellationToken);
    }
}
