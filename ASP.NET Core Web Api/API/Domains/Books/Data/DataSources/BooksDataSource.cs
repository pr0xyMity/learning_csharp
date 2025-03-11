using API.Domains.Books.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Domains.Books.Data.DataSources;

public interface IBooksDatasource
{
   /// <summary>
   /// Get single book details with the book ID.
   /// </summary>
   Task<Book?> GetBook(string bookId);
   
   /// <summary>
   /// Get whole list of available books.
   /// </summary>
   Task<List<Book>> GetBooks();
}

public class BooksDataSource: IBooksDatasource
{
   
   public async Task<Book?> GetBook(string bookId)
   {
      await Task.Delay(1);
      return
         new Book( "How I learn" );
   }

   public async Task<List<Book>> GetBooks()
   {
      await Task.Delay(1);
      return new List<Book>([
         new Book( "How I learn" ),
         new Book( "How I sleep" ),
         new Book( "How I design" ),
         new Book( "How I think" ),
            ]
      )!;
   }
}