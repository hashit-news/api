/// <inheritdoc/>
public class UserRepository : Repository<User>, IUserRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="db"></param>
    public UserRepository(HashitDbContext db) : base(db) { }

    public Task<bool> IsUserWithWalletExistsAsync(
        string walletAddress,
        CancellationToken cancellationToken = default
    )
    {
        throw new NotImplementedException();
    }
}
