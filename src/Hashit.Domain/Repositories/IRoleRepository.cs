/// <summary>
/// Repository for a role.
/// </summary>
public interface IRoleRepository : IRepository<Role>
{
    /// <summary>
    /// Finds a role by its id.
    /// </summary>
    /// <param name="id">Role id</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Role if found, othwerwise null.</returns>
    ValueTask<Role?> FindByIdAsync(RoleType id, CancellationToken cancellationToken = default);
}
