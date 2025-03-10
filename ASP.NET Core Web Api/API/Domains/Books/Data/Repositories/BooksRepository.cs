using API.Domains.Books.Data.DataSources;
using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Repositories;

namespace API.Domains.Books.Data.Repositories;

public class BooksRepository : IBooksRepository
{

    public BooksRepository(IBooksDatasource booksDatasource)
    {
       _booksDatasource = booksDatasource ?? throw new ArgumentNullException(nameof(booksDatasource)); 
    }
    
    IBooksDatasource  _booksDatasource;
    
    public Task addBook(Book book)
    {
        throw new NotImplementedException();
    }

    public Task removeBook(Book book)
    {
        throw new NotImplementedException();
    }

    public async Task<Book?> getBookById(Guid bookId)
    {
        return await _booksDatasource.getBook(bookId);
    }

    public async Task<List<Book?>> getBooks()
    {
        return await _booksDatasource.getBooks();
    }
}