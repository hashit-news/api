using System.ComponentModel.DataAnnotations;

/// <summary>
/// Paramneters to get a user's web3 login info.
/// </summary>
public sealed class Web3LoginInfoParams
{
    /// <summary>
    /// The user's public ethereum wallet address.
    /// </summary>
    [Required]
    public string WalletAddress { get; set; } = null!;
}
