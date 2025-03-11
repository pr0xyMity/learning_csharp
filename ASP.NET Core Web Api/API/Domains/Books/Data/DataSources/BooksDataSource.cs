using API.Domains.Books.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Domains.Books.Data.DataSources;

public interface IBooksDatasource
{
   /// <summary>
   /// Get single book details with the book ID.
   /// </summary>
   Task<BookDTO?> getBook(Guid bookId);
   
   /// <summary>
   /// Get whole list of available books.
   /// </summary>
   Task<List<BookDTO?>> getBooks();
}

public class BooksDataSource: IBooksDatasource
{
   
   public async Task<BookDTO?> getBook(Guid bookId)
   {
      await Task.Delay(1);
      return
         new BookDTO(
            "How I learn",
            new Author("Bob", "Fischer", "bob.fischer@gmail.com"),
            null
         );
   }

   public async Task<List<BookDTO?>> getBooks()
   {
      await Task.Delay(1);
      return new List<BookDTO>([
            new BookDTO(
               "How I learn",
               new Author("Bob", "Fischer", "bob.fischer@gmail.com"),
               null
            ),
            new BookDTO(
               "How I sleep",
               new Author("Martin", "Robert", "martin.robert@gmail.com"),
               null
            )]
      )!;
   }
}