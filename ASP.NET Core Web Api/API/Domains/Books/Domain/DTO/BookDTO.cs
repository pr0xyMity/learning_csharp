namespace API.Domains.Books.Domain;

public class BookDTO
{
    public BookDTO(string id, string title, ICollection<AuthorWithoutBooksDTO> authors)
    {
        Id = id;
        Title = title;
        Authors = authors;
    }

    public string Id { get; set; }

    public string Title { get; set; }

    public ICollection<AuthorWithoutBooksDTO> Authors { get; set; }

    public int NumberOfAuthors => Authors.Count();
}