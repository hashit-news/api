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
    public int Id { get; protected set; }

    /// <summary>
    /// Unique username of the user.
    /// </summary>
    [MaxLength(20)]
    public string? Username { get; protected internal set; }

    /// <summary>
    /// Email address of the user.
    /// </summary>
    [MaxLength(255)]
    public string? Email { get; protected internal set; }

    /// <summary>
    /// Whether the email address has been verified.
    /// </summary>
    public bool EmailVerified { get; protected internal set; }

    /// <summary>
    /// The user's public wallet address used to login.
    /// </summary>
    [Required]
    [MaxLength(40)]
    public string WalletAddress { get; protected internal set; } = null!;

    /// <summary>
    /// Randomly generated nonce used to sign and verify a user's wallet address.
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string WalletSigningNonce { get; protected internal set; } = null!;

    /// <summary>
    /// Last time the user logged in.
    /// </summary>
    public Instant? LastLoggedInAt { get; protected internal set; }

    /// <summary>
    /// Number of times the user attempted to logged in bu failed.
    /// </summary>
    public int FailedLoginAttempts { get; protected internal set; }

    /// <summary>
    /// Time until the user can attempt login again after being locked for too many failed attempts.
    /// </summary>
    public Instant? LockoutExpiryAt { get; protected internal set; }

    /// <summary>
    /// User's roles.
    /// </summary>
    public ICollection<UserRole> UserRoles { get; protected internal set; } = null!;

    public void AddRole(Role role)
    {
        if (!UserRoles.Any(ur => ur.RoleId == role.Id))
        {
            UserRoles.Add(new UserRole { UserId = Id, RoleId = role.Id });
        }
    }
}
