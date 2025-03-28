using API.Domains.Books;

namespace API.Domains.Authentication.Domain.Services;

public interface IAuthenticationService
{
    string CreateToken(User user);
    User? ValidateUserCredentials(string? username, string? password);
}