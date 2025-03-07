using API.Domains.Books.Data.DataSources;
using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Repositories;

namespace API.Domains.Books.Data.Repositories;

public class BooksRepository : IBooksRepository
{

    public BooksRepository(IBooksDatasource booksDatasource)
    {
       _booksDatasource = booksDatasource; 
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

    public async Task<Book?> getBookById(string bookId)
    {
        return await _booksDatasource.getBook(bookId);
    }

    public Task<List<Book?>> getBooks()
    {
        throw new NotImplementedException();
    }
}