namespace API.Domains.Authentication.Domain.Dto;

public abstract class AuthenticationRequestDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}