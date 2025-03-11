using System.ComponentModel.DataAnnotations;

namespace API.Domains.Books.Domain;

public class BookCreateDTO
{
 
   public Guid Id  { get; set; } 
   public string Title  { get; set; } 
   public Author Author  { get; set; } 
  public string? Publisher  { get; set; }

   public BookCreateDTO(Guid id, string title, Author author, string? publisher)
   {
       Id = id;
     Title = title;
     Author = author;
     Publisher = publisher;
   }
}