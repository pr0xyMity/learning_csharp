namespace API.Domains.Books.Domain.Models;

public class BookModel
{
    public BookModel(string id, string title, ICollection<Author> authors)
    {
        Id = id;
        Title = title;
        Authors = authors;
    }

    public string Id { get; set; }

    public string Title { get; set; }

    public ICollection<Author> Authors { get; set; }

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