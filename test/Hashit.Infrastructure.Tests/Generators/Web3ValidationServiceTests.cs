using Nethereum.Util;

public sealed class Web3ValidationServiceTests
{
    [Theory]
    [InlineData("0x0", "", true, "'address' cannot be an empty address. (Parameter 'address')")]
    [InlineData("", "", true, "'address' cannot be null or whitespace. (Parameter 'address')")]
    [InlineData(null, "", true, "'address' cannot be null or whitespace. (Parameter 'address')")]
    [InlineData(
        "I like turtles.",
        "",
        true,
        "'address' is not a valid Ethereum address. (Parameter 'address')"
    )]
    [InlineData(
        "0x8ba1f109551bD432803012645Ac136ddd64DBA72",
        "0x8ba1f109551bD432803012645Ac136ddd64DBA72",
        false,
        ""
    )]
    [InlineData(
        "0x8ba1f109551bD432803012645Ac136ddd64dba72",
        "0x8ba1f109551bD432803012645Ac136ddd64DBA72",
        false,
        ""
    )]
    [InlineData(
        "0x8ba1f109551bd432803012645ac136ddd64dba72",
        "0x8ba1f109551bD432803012645Ac136ddd64DBA72",
        false,
        ""
    )]
    [InlineData(
        "0x8Ba1f109551bD432803012645Ac136ddd64DBA72",
        "0x8ba1f109551bD432803012645Ac136ddd64DBA72",
        false,
        ""
    )]
    public void ShouldEnsureEthereumAddress(
        string address,
        string expected,
        bool throws,
        string message
    )
    {
        // arrange
        var service = new Web3ValidationService();

        // act
        // assert
        if (throws)
        {
            service
                .Invoking(s => s.EnsureChecksumAddress(address))
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(message);
        }
        else
        {
            var actual = service.EnsureChecksumAddress(address);
            actual.Should().Be(expected);
        }
    }
}
