/// <summary>
/// A repository.
/// </summary>
public interface IRepository
{
    /// <summary>
    /// The unit of work for this repository.
    /// </summary>
    IUnitOfWork UnitOfWork { get; }
};

/// <summary>
/// A repository.
/// </summary>
/// <typeparam name="T">The type of entity in the repository.</typeparam>
public interface IRepository<T> : IRepository where T : Entity
{
    /// <summary>
    /// Inserts an entity into the repository.
    /// </summary>
    /// <param name="entity">Entity being inserted</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task Insert(T entity, CancellationToken cancellationToken = default);
}
