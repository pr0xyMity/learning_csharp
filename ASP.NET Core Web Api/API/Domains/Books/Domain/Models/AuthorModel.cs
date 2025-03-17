namespace API.Domains.Books.Domain.Models;

public class AuthorModel
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public string? Email { get; set; }

    public ICollection<BookModelWithoutAuthors> Books { get; set; }
}