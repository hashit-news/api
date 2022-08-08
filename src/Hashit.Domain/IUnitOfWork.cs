public interface IUnitOfWork
{
    /// <summary>
    /// Commits changes made in a transaction.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CommitAsync(CancellationToken cancellationToken = default);
}
