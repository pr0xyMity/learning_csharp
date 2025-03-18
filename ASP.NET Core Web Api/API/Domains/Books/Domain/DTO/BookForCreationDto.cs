namespace API.Domains.Books.Domain;

public class BookForCreationDto
{
    public string Title { get; set; }

    public ICollection<string> AuthorsIds { get; set; }
}