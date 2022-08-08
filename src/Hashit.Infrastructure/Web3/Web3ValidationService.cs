using Nethereum.Util;

public class Web3ValidationService : IWeb3ValidationService
{
    public string EnsureChecksumAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException(
                $"'{nameof(address)}' cannot be null or whitespace.",
                nameof(address)
            );

        if (AddressUtil.Current.IsAnEmptyAddress(address))
            throw new ArgumentException(
                $"'{nameof(address)}' cannot be an empty address.",
                nameof(address)
            );

        if (!AddressUtil.Current.IsValidEthereumAddressHexFormat(address))
            throw new ArgumentException(
                $"'{nameof(address)}' is not a valid Ethereum address.",
                nameof(address)
            );

        return AddressUtil.Current.ConvertToChecksumAddress(address);
    }
}
