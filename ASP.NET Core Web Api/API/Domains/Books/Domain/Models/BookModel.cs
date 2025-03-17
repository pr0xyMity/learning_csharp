namespace API.Domains.Books.Domain.Models;

public class BookModel
{
    public string Id { get; set; }

    public string Title { get; set; }

    public ICollection<AuthorModel> Authors { get; set; } = new List<AuthorModel>();

    public bool IsBookEbook()
    {
        return Id.Contains("EB");
    }

    public bool IsBookAvailable()
    {
        return !Title.Contains("Available");
    }

    public bool IsWrittenBySingeAuthor()
    {
        return Authors.Count > 1;
    }
}