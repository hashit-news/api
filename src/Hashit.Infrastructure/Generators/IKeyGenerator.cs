/// <summary>
/// Used to generate unique keys for common usage patterns.
/// </summary>
public interface IKeyGenerator
{
    /// <summary>
    /// Generates a unique 256-bit symmetrical key.
    /// </summary>
    /// <returns>Generated key.</returns>
    string Generate256BitKey();
}
