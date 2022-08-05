/// <inheritdoc />
public class UserDomainService : IUserDomainService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserDomainService"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="roleRepository"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public UserDomainService(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
    }

    /// <inheritdoc />
    public async Task<User?> CreateNewUserAsync(
        string walletAddress,
        CancellationToken cancellationToken = default
    )
    {
        var exists = await _userRepository.IsUserWithWalletExistsAsync(
            walletAddress,
            cancellationToken
        );

        if (!exists)
        {
            var defaultRole = await _roleRepository.FindByIdAsync(RoleType.User, cancellationToken);
            var user = new User()
            {
                WalletAddress = walletAddress,
                Username = walletAddress,
                WalletSigningNonce = "blah",
            };

            user.AddRole(defaultRole);

            await _userRepository.Insert(user, cancellationToken);
            await _userRepository.UnitOfWork.CommitAsync(cancellationToken);

            return user;
        }

        return null;
    }
}
