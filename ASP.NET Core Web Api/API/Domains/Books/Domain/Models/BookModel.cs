namespace API.Domains.Books.Domain.Models;

public class BookModel
{
    public string Id { get; set; }

    public string Title { get; set; }

    public ICollection<string> AuthorsIds { get; set; } = new List<string>();

    public bool IsBookEbook()
    {
        return Id.Contains("EB");
    }
}