public enum RoleId
{
    /// <summary>
    /// A user with this role has full access all protected resources.
    /// </summary>
    Admin,

    /// <summary>
    /// A user with this role has acess to their own protected resources.
    /// </summary>
    User,
}

/// <summary>
/// A role in the system that protecteds access to resources.
/// </summary>
public class Role : Entity
{
    /// <summary>
    /// The role id.
    /// </summary>
    [Key]
    public RoleId Id { get; set; }
}
