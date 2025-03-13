namespace API.Domains.Books.Domain.Models;

public class AuthorModel
{
    public AuthorModel(string id, string name, ICollection<Book> books)
    {
        Id = id;
        Name = name;
        Books = books;
    }

    public string Id { get; set; }

    public string Name { get; set; }

    public ICollection<Book> Books { get; set; }

    public bool HasAuthorBooks()
    {
        return Books.Count > 0;
    }
}