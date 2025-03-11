namespace API.Domains.Books.Domain.Models;

public class BookModel
{
    public string Id { get; set; }
    
    public string Title  { get; set; } 
    
    public ICollection<Author> Author  { get; set; }

    public BookModel(string id, string title, ICollection<Author> author)
    {
        Id = id;
        Title = title;
        Author = author;
    }
    
   public bool IsBookEbook()
   {
       return Id.Contains("EB");
   }
   
   public bool IsBookAvailable()
   {
       return !Title.Contains("Available");
   }
   
   public bool IsWrittenBySingeAuthor()
   {
       return Author.Count > 1;
   }
   
   
}