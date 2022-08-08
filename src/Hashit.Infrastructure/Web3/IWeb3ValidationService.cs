/// <summary>
/// Common web3 validation methods.
/// </summary>
public interface IWeb3ValidationService
{
    /// <summary>
    /// Ensures address is valid checksum eth address and converts to proper casing.
    /// </summary>
    /// <param name="address">Public eth address.</param>
    /// <returns>Returns checksum address with proper casing.</returns>
    string EnsureChecksumAddress(string address);
}
