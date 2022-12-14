using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

public sealed class HealthTests
{
    private readonly HttpClient _client;

    public HealthTests()
    {
        _client = new WebApplicationFactory<Program>().CreateClient();
    }

    [Fact]
    public async Task Health_Returns_200()
    {
        var response = await _client.GetAsync("/health");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Response_Contains_Request_ID()
    {
        var response = await _client.GetAsync("/health");

        response.Headers.Should().ContainKey(CustomHeaders.RequestId);
    }
}
