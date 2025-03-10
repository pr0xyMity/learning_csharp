using API.Domains.Books.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Domains.Books.Data.DataSources;

public interface IBooksDatasource
{
   /// <summary>
   /// Get single book details with the book ID.
   /// </summary>
   Task<Book?> getBook(Guid bookId);
   
   /// <summary>
   /// Get whole list of available books.
   /// </summary>
   Task<List<Book?>> getBooks();
}

public class BooksDataSource: IBooksDatasource
{
   
   public async Task<Book?> getBook(Guid bookId)
   {
      return
         new Book(
            "How I learn",
            new Author("Bob", "Fischer", "bob.fischer@gmail.com"),
            null
         );
   }

   public Task<List<Book?>> getBooks()
   {
      throw new NotImplementedException();
   }
}