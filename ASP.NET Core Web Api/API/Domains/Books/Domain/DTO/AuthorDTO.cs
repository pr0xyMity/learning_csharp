namespace API.Domains.Books.Domain;

public class AuthorDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public ICollection<BookDTO> Books { get; set; } = new List<BookDTO>();
}