namespace API.Domains.Books.Domain.Models;

public class AuthorWithoutBooksModel
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public string? Email { get; set; }
}