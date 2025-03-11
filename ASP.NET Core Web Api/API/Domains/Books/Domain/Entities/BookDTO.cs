using System.ComponentModel.DataAnnotations;

namespace API.Domains.Books.Domain;

public class BookDTO
{
 
    [Required]
    [MaxLength(100)]
   public string Title  { get; set; } 
    [Required]
   public Author Author  { get; set; } 
  public string? Publisher  { get; set; }

   public BookDTO(string title, Author author, string? publisher)
   {
     Title = title;
     Author = author;
     Publisher = publisher;
   }
}