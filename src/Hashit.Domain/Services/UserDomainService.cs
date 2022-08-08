/// <inheritdoc />
public class UserDomainService : IUserDomainService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IKeyGenerator _keyGenerator;
    private readonly IWeb3ValidationService _web3ValidationService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserDomainService"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="roleRepository"></param>
    /// <param name="keyGenerator"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public UserDomainService(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IKeyGenerator keyGenerator,
        IWeb3ValidationService web3ValidationService
    )
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        _keyGenerator = keyGenerator ?? throw new ArgumentNullException(nameof(keyGenerator));
        _web3ValidationService =
            web3ValidationService ?? throw new ArgumentNullException(nameof(web3ValidationService));
    }

    public async Task<User> CreateNewUserAsync(
        string walletAddress,
        CancellationToken cancellationToken = default
    )
    {
        var formattedWalletAddress = _web3ValidationService.EnsureChecksumAddress(walletAddress);

        var exists = await _userRepository.IsUserWithWalletExistsAsync(
            formattedWalletAddress,
            cancellationToken
        );

        if (exists)
            throw new DomainException(
                DomainExceptionType.InvalidOperation,
                $"User with wallet address '{formattedWalletAddress}' already exists."
            );

        var defaultRole = await _roleRepository.FindByIdAsync(RoleType.User, cancellationToken);

        if (defaultRole is null)
            throw new DomainException(
                DomainExceptionType.InvalidOperation,
                "Default role not found."
            );

        var user = new User()
        {
            WalletAddress = formattedWalletAddress,
            Username = formattedWalletAddress,
            WalletSigningNonce = _keyGenerator.Generate256BitKey(),
        };

        user.AddRole(defaultRole);

        await _userRepository.Insert(user, cancellationToken);
        await _userRepository.UnitOfWork.CommitAsync(cancellationToken);

        return user;
    }
}
