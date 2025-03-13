namespace API.Domains.Books.Domain;

public class AuthorWithoutBooksDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
}