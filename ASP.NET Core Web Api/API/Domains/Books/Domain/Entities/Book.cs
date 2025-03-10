namespace API.Domains.Books.Domain;

public class Book
{
   public string Title  { get; set; } 
   public Author Author  { get; set; } 
  public string? Publisher  { get; set; }

   public Book(string title, Author author, string? publisher)
   {
     Title = title;
     Author = author;
     Publisher = publisher;
   }
}