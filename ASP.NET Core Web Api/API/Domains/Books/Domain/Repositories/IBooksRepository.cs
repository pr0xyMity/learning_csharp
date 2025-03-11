namespace API.Domains.Books.Domain.Repositories;

public interface IBooksRepository
{
    Task addBook(BookDTO bookDto);
    Task removeBook(BookDTO bookDto);
    Task<BookDTO?> getBookById(string bookId);
    Task<List<BookDTO?>> getBooks();
}