using System.Security.Cryptography;

/// <inheritdoc />
public class KeyGenerator : IKeyGenerator
{
    /// <inheritdoc />
    public string Generate256BitKey()
    {
        var aes = Aes.Create();
        var key = Convert.ToBase64String(aes.Key);

        return key;
    }
}
