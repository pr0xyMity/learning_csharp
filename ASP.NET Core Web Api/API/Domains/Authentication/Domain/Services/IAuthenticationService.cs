using API.Domains.Authentication.Domain.Dto;
using API.Domains.Books;

namespace API.Domains.Authentication.Domain.Services;

public interface IAuthenticationService
{
    string CreateToken(User user);
    User? ValidateUserCredentials(AuthenticationRequestBodyDto authenticationRequestBodyDto);
    Task<User> CreateUser(RegisterRequestBodyDto registerRequestBodyDto);
    Task<bool> EmailExists(string email);
}