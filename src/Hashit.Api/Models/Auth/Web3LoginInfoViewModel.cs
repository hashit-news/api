using System.ComponentModel.DataAnnotations;

/// <summary>
/// Details about a user's wallet login.
/// </summary>
public sealed class Web3LoginInfoViewModel
{
    /// <summary>
    /// Creates a new instance of <see cref="Web3LoginInfoViewModel"/>.
    /// </summary>
    /// <param name="userId">The user's id.</param>
    /// <param name="walletAddress">The user's public ethereum wallet address.</param>
    /// <param name="unsignedMessage">The message that the user will sign with their wallet for verification.</param>
    /// <returns></returns>
    public Web3LoginInfoViewModel(int userId, string walletAddress, string unsignedMessage)
    {
        WalletAddress = walletAddress;
        UnsignedMessage = unsignedMessage;
        UserId = userId;
    }

    /// <summary>
    /// The user's id.
    /// </summary>
    [Required]
    public int UserId { get; }

    /// <summary>
    /// The user's public ethereum wallet address.
    /// </summary>
    [Required]
    public string WalletAddress { get; }

    /// <summary>
    /// The message that the user will sign with their wallet for verification.
    /// </summary>
    [Required]
    public string UnsignedMessage { get; }
}
