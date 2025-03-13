using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domains.Books.Domain;

public class Author
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    [Required] [MaxLength(50)] public string Name { get; set; }
    [MaxLength(60)] [EmailAddress] public string? Email { get; set; }
    [Required] public List<Book> Books { get; set; } = new();
}