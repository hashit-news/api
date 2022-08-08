/// <summary>
/// Represents a user's role in the system.
/// </summary>
public class UserRole : Entity
{
    /// <summary>
    /// Id of the user.
    /// </summary>
    public int UserId { get; protected internal set; }

    /// <summary>
    /// User.
    /// </summary>
    public User User { get; protected internal set; } = null!;

    /// <summary>
    /// The user's role.
    /// </summary>
    public RoleType RoleId { get; protected internal set; }

    /// <summary>
    /// The user's role.
    /// </summary>
    public Role Role { get; protected internal set; } = null!;
}
