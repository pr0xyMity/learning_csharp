using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domains.Books.Domain;

public class Author
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id  { get; set; } 
    
    [Required] 
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required] 
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [MaxLength(60)]
    [EmailAddress]
    public string? Email { get; set; }
    
    [ForeignKey("BookId")]
    public Book? Book { get; set; }
    public string? CityId { get; set; }

    public Author(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}