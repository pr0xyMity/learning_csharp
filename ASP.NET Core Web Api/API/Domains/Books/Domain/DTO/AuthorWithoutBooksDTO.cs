namespace API.Domains.Books.Domain;

public class AuthorWithoutBooksDTO
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
}