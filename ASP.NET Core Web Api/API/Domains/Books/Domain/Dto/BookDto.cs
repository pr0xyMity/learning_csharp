namespace API.Domains.Books.Domain;

public class BookDto
{
    public string Id { get; set; }

    public string Title { get; set; }

    public ICollection<AuthorWithoutBooksDto> Authors { get; set; }

    public int NumberOfAuthors => Authors.Count();
}