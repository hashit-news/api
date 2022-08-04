/// <summary>
/// Represents an entity in the system.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// They primary key identifying the entity.
    /// </summary>
    public abstract object[] Key { get; }

    /// <summary>
    /// Time the entity was created.
    /// </summary>
    public Instant CreatedAt { get; set; }

    /// <summary>
    /// Time the entity was last updated.
    /// </summary>
    public Instant UpdatedAt { get; set; }
}
