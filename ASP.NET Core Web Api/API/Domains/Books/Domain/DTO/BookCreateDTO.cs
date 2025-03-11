using System.ComponentModel.DataAnnotations;

namespace API.Domains.Books.Domain;

public class BookCreateDTO
{
    [Required]
   public string Title  { get; set; } 
    [Required]
   public ICollection<Author> Author  { get; set; } 

   public BookCreateDTO(Guid id, string title, ICollection<Author> author)
   {
     Title = title;
     Author = author;
   }
}