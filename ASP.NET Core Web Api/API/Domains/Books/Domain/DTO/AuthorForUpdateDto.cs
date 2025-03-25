namespace API.Domains.Books.Domain;

public class AuthorForUpdateDto
{
    public required string Name { get; set; }
    public string? Email { get; set; }
}