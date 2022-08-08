/// <summary>
/// A role in the system that protecteds access to resources.
/// </summary>
public class Role : Entity
{
    /// <summary>
    /// Creates a new role.
    /// </summary>
    /// <param name="id">RoleType</param>
    public Role(RoleType id)
    {
        Id = id;
    }

    /// <summary>
    /// The role id.
    /// </summary>
    [Key]
    public RoleType Id { get; protected set; }
}
