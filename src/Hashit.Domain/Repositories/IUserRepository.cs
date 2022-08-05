/// <summary>
/// Interface for a user repository.
/// </summary>
public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Checks to see if a user with a wallet address exists.
    /// </summary>
    /// <param name="walletAddress">The wallet address of the user.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>True if exists.</returns>
    Task<bool> IsUserWithWalletExistsAsync(
        string walletAddress,
        CancellationToken cancellationToken = default
    );
}
