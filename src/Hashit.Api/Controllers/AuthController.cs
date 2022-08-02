using Microsoft.AspNetCore.Authorization;

/// <summary>
/// Endpoints for authentication and authorization.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces(ContentTypes.ApplicationJson)]
public sealed class AuthController : ControllerBase
{
    /// <summary>
    /// Gets info needed for login for an existing user's wallet login or creates a new one based on the provided wallet address.
    /// </summary>
    /// <param name="parameters">Paramneters to get a user's web3 login info.</param>
    /// <returns>The web3 login info.</returns>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(Web3LoginInfoViewModel), 200)]
    public Task<IActionResult> GetWeb3LoginInfo([FromQuery] Web3LoginInfoParams parameters)
    {
        throw new NotImplementedException();
    }
}
