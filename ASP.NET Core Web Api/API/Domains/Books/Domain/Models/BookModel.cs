namespace API.Domains.Books.Domain.Models;

public class BookModel
{
    public string Id { get; set; }

    public string Title { get; set; }

    public ICollection<AuthorWithoutBooksModel> Authors { get; set; } = new List<AuthorWithoutBooksModel>();

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