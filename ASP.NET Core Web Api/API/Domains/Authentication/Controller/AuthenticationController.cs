using API.Domains.Authentication.Domain.Dto;
using API.Domains.Authentication.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Domains.Books;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService =
            authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
    }

    [HttpPost]
    public async Task<ActionResult<string>> Register(RegisterRequestBodyDto registerRequestBodyDto)
    {
        // Step 1. Check if email is used 
        var emailExists = await _authenticationService.EmailExists(registerRequestBodyDto.Email);

        if (emailExists) return BadRequest("Email already exists");

        var user = await _authenticationService.CreateUser(registerRequestBodyDto);

        // Step 2. Check if user is created 
        return Ok("Register");
    }

    [HttpPost]
    public ActionResult<string> Authenticate(AuthenticationRequestBodyDto authenticationRequestBodyDto)
    {
        var user = _authenticationService.ValidateUserCredentials(
            authenticationRequestBodyDto);

        if (user == null) return Unauthorized();

        var tokenToReturn = _authenticationService.CreateToken(user);

        return Ok(tokenToReturn);
    }
}