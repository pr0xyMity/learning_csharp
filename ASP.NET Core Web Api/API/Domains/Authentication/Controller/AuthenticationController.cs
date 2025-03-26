using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Domains.Books;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthenticationController(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    [HttpPost]
    public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
    {
        // Step 1. Validation of the credentials
        var user = ValidateUserCredentials(authenticationRequestBody.Username, authenticationRequestBody.Password);

        if (user == null) return Unauthorized();

        // Step 2. Prepare for token creation
        var securityKey = new SymmetricSecurityKey(
            Convert.FromBase64String(_configuration["Authentication:Secret"]));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Step 3. Claims for token
        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
        claimsForToken.Add(new Claim("given_name", user.FirstName));
        claimsForToken.Add(new Claim("family_name", user.LastName));

        // Step 4. Create the token
        var jwtSecurityToken = new JwtSecurityToken(
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            signingCredentials
        );

        var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return Ok(tokenToReturn);
    }

    public User? ValidateUserCredentials(string? username, string? password)
    {
        // This is just for simplicity
        return new User(1, "Tony", "Montana");
    }

    public class AuthenticationRequestBody
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class User
    {
        public User(
            int userId,
            string firstName,
            string lastName
        )
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}