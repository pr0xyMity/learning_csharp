namespace API.Domains.Books.Domain.Repositories;

public interface IBooksRepository
{
    Task addBook(Book book);
    Task removeBook(Book book);
    Task<Book?> getBookById(Guid bookId);
    Task<List<Book?>> getBooks();
}