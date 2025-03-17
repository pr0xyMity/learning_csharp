namespace API.Domains.Books.Domain;

public class AuthorDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public ICollection<BookWithoutAuthorsDto> Books { get; set; }
}