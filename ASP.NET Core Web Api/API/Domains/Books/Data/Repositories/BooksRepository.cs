using API.Domains.Books.Data.DataSources;
using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Models;
using API.Domains.Books.Domain.Repositories;

namespace API.Domains.Books.Data.Repositories;

public class BooksRepository : IBooksRepository
{

    public BooksRepository(IBooksDatasource booksDatasource)
    {
       _booksDatasource = booksDatasource ?? throw new ArgumentNullException(nameof(booksDatasource)); 
    }
    
    IBooksDatasource  _booksDatasource;
    
    public Task AddBook(BookDTO bookDto)
    {
        throw new NotImplementedException();
    }

    public Task RemoveBook(string bookId)
    {
        throw new NotImplementedException();
    }

    public async Task<BookModel> GetBookById(string bookId)
    {
        Book? book = await _booksDatasource.GetBook(bookId);

        if (book == null)
        {
            throw new Exception($"Book with {bookId} was not found");
        }

        return new BookModel(book.Id, book.Title, book.Authors);
    }

    public async Task<List<BookModel>> GetBooks()
    {
        List<Book> books = await _booksDatasource.GetBooks();

        if (books.Count == 0)
        {
            return new List<BookModel>();
        }
        else
        {
            List<BookModel> booksModel = books
                .Select(book => new BookModel(book.Id, book.Title, book.Authors))
                .ToList();
            return booksModel;
        }
    }
}