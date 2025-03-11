using System.ComponentModel.DataAnnotations;

namespace API.Domains.Books.Domain;

public class BookDTO
{
    public string Id { get; set; }
    
    public string Title  { get; set; } 
    
    public ICollection<AuthorDTO> Author  { get; set; } = new List<AuthorDTO>();

    public int NumberOfAuthors
    {
        get
        {
            return Author.Count();
        }
    }
}