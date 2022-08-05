/// <summary>
/// User domain service.
/// </summary>
public interface IUserDomainService
{
    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="walletAddress">User's public wallet address.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>User if created, otherwise null.</returns>
    Task<User?> CreateNewUserAsync(
        string walletAddress,
        CancellationToken cancellationToken = default
    );
}
