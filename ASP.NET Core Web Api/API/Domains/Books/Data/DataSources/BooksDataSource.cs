using API.Domains.Books.Domain;

namespace API.Domains.Books.Data.DataSources;

interface IBooksDatasource
{
   /// <summary>
   /// Get single book.
   /// </summary>
   Book getBook(string bookId);
}

public class BooksDataSource
{
    
}