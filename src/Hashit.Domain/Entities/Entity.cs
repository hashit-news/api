/// <summary>
/// Represents an entity in the system.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Time the entity was created.
    /// </summary>
    public Instant CreatedAt { get; protected set; }

    /// <summary>
    /// Time the entity was last updated.
    /// </summary>
    public Instant UpdatedAt { get; protected set; }
}
