/// <summary>
/// A repository.
/// </summary>
/// <typeparam name="T">The type of entity in the repository.</typeparam>
public interface IRepository<T> where T : Entity
{
    /// <summary>
    /// The unit of work for this repository.
    /// </summary>
    IUnitOfWork UnitOfWork { get; }

    /// <summary>
    /// Inserts an entity into the repository.
    /// </summary>
    /// <param name="entity">Entity being inserted</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task Insert(T entity, CancellationToken cancellationToken = default);
}
