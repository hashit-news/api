using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// A user of the application.
/// </summary>
public class User : Entity
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Unique username of the user.
    /// </summary>
    [MaxLength(20)]
    public string? Username { get; set; }

    /// <summary>
    /// Email address of the user.
    /// </summary>
    [MaxLength(255)]
    public string? Email { get; set; }

    /// <summary>
    /// Whether the email address has been verified.
    /// </summary>
    public bool EmailVerified { get; set; }

    /// <summary>
    /// The user's public wallet address used to login.
    /// </summary>
    [Required]
    [MaxLength(40)]
    public string WalletAddress { get; set; } = null!;

    /// <summary>
    /// Randomly generated nonce used to sign and verify a user's wallet address.
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string WalletSigningNonce { get; set; } = null!;

    /// <summary>
    /// Last time the user logged in.
    /// </summary>
    public Instant? LastLoggedInAt { get; set; }

    /// <summary>
    /// Number of times the user attempted to logged in bu failed.
    /// </summary>
    public int FailedLoginAttempts { get; set; }

    /// <summary>
    /// Time until the user can attempt login again after being locked for too many failed attempts.
    /// </summary>
    public Instant? LockoutExpiryAt { get; set; }

    public override object[] Key => new object[] { Id };
}
