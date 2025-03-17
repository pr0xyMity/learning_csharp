namespace API.Domains.Books.Domain;

public class AuthorForCreationDto
{
    public required string Name { get; set; }
    public string? Email { get; set; }
}