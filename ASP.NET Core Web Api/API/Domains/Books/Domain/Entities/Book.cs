namespace API.Domains.Books.Domain;

public class Book
{
   String Title  { get; set; } 
   Author Author  { get; set; } 
   String? Publisher  { get; set; }

   Book(string title, Author author, string? publisher)
   {
     Title = title;
     Author = author;
     Publisher = publisher;
   }
}