using API.Domains.Books.Data.DataSources;
using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Repositories;

namespace API.Domains.Books.Data.Repositories;

public class BooksRepository : IBooksRepository
{

    BooksRepository(IBooksDatasource booksDatasource)
    {
       _booksDatasource = booksDatasource; 
    }
    
    IBooksDatasource  _booksDatasource;
    
    public void addBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void removeBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void getBookById(string bookId)
    {
        throw new NotImplementedException();
    }

    public void getBooks()
    {
        throw new NotImplementedException();
    }
}