using System.ComponentModel.DataAnnotations;

namespace API.Domains.Books.Domain;

public class BookDTO
{
    public string Id { get; set; }
    
    public string Title  { get; set; } 
    
    public ICollection<Author> Author  { get; set; }

    public int NumberOfAuthors
    {
        get
        {
            return Author.Count();
        }
    }

    public BookDTO(string id, string title, ICollection<Author> author)
    {
        Id = id;
        Title = title;
        Author = author;
    }
}