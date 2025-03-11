using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domains.Books.Domain;

public class Book
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id  { get; set; } 
    
    [Required] 
    [MaxLength(100)]
    public string Title  { get; set; } 
    
    [Required] 
    public ICollection<Author> Authors  { get; set; }

    public Book(string title)
    {
        Title = title;
        Authors = new List<Author>();
    } 
}