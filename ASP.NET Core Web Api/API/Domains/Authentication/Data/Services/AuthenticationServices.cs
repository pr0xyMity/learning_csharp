using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API.Domains.Authentication.Domain.Dto;
using API.Domains.Authentication.Domain.Services;
using API.Domains.Books;
using Microsoft.IdentityModel.Tokens;

namespace API.Domains.Authentication.Domain;

public class AuthenticationServices : IAuthenticationService
{
    private readonly IConfiguration _configuration;

    public AuthenticationServices(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public string CreateToken(User user)
    {
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

        return tokenToReturn;
    }

    public Task<User> CreateUser(RegisterRequestBodyDto registerRequestBodyDto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> EmailExists(string? email)
    {
        await Task.Delay(100);
        return email != null && email.Contains("konrad");
    }

    public User? ValidateUserCredentials(AuthenticationRequestBodyDto authenticationRequestBodyDto)
    {
        if (
            authenticationRequestBodyDto.Email == null ||
            authenticationRequestBodyDto.Username == null ||
            authenticationRequestBodyDto.Password == null
        )
            return null;

        return new User
        {
            Email = authenticationRequestBodyDto.Email,
            UserName = authenticationRequestBodyDto.Username
        };
    }
}