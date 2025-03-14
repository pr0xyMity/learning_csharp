using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domains.Books.Domain;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    [Required] [MaxLength(100)] public string Title { get; set; }

    [Required]
    [MinLength(1, ErrorMessage = "Book must at least have one author.")]
    public ICollection<Author> Authors { get; set; } = new List<Author>();

    [MaxLength(400)] public string? Description { get; set; }
}