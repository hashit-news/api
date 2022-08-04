/// <summary>
/// A role in the system that protecteds access to resources.
/// </summary>
public class Role : Entity
{
    /// <summary>
    /// The role id.
    /// </summary>
    [Key]
    public RoleType Id { get; set; }

    public override object[] Key => new object[] { Id };
}
