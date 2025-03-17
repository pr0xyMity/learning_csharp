using System.ComponentModel.DataAnnotations;

namespace API.Domains.Books.Domain;

public class BookCreateDto
{
    public BookCreateDto(Guid id, string title, ICollection<Author> author)
    {
        Title = title;
        Author = author;
    }

    [Required] public string Title { get; set; }

    [Required] public ICollection<Author> Author { get; set; }
}