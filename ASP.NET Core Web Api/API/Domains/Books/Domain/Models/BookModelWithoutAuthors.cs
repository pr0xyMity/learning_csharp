namespace API.Domains.Books.Domain.Models;

public class BookModelWithoutAuthors
{
    public string Id { get; set; }

    public string Title { get; set; }

    public bool IsBookEbook()
    {
        return Id.Contains("EB");
    }

    public bool IsBookAvailable()
    {
        return !Title.Contains("Available");
    }
}