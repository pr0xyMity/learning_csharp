namespace API.Domains.Books.Domain;

public class BookDTO
{
    public BookDTO(string id, string title, ICollection<Author> authors)
    {
        Id = id;
        Title = title;
        Authors = authors;
    }

    public string Id { get; set; }

    public string Title { get; set; }

    public ICollection<Author> Authors { get; set; }

    public int NumberOfAuthors => Authors.Count();
}