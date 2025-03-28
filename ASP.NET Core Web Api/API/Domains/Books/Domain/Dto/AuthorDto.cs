using System.ComponentModel.DataAnnotations;

namespace API.Domains.Books.Domain;

public class AuthorDto : AuthorForManipulationDto
{
    [Required] public required string Id { get; set; }

    public ICollection<BookWithoutAuthorsDto> Books { get; set; }
}