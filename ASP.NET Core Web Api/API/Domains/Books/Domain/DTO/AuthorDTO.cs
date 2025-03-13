namespace API.Domains.Books.Domain;

public class AuthorDTO
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public required ICollection<BookDTO> Books { get; set; } = new List<BookDTO>();
}