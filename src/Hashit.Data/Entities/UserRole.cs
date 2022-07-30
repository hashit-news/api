/// <summary>
/// Represents a user's role in the system.
/// </summary>
public class UserRole : Entity
{
    /// <summary>
    /// Id of the user.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// User.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// The user's role.
    /// </summary>
    public RoleType RoleId { get; set; }

    /// <summary>
    /// The user's role.
    /// </summary>
    public Role Role { get; set; } = null!;
}
