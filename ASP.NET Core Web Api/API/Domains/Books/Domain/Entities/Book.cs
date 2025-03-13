using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domains.Books.Domain;

public class Book
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    
    [Required] 
    [MaxLength(100)]
    public string Title { get; set; }
    
    [Required] 
    [MinLength(1)]
    public ICollection<Author> Authors { get; set; } = new List<Author>();
    
    [Required]
    [MaxLength(400)]
    public string Description { get; set; }

    // Private parameterless constructor for EF Core
    private Book() {}

    // Public constructor for domain logic
    public Book(string title, ICollection<Author> authors)
    {
        Title = title;
        Authors = authors ?? throw new ArgumentNullException(nameof(authors));
        
        if (authors.Count == 0)
            throw new ArgumentException("At least one author is required", nameof(authors));
    }
}