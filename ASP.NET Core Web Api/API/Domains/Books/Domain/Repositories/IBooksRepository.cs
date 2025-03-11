using API.Domains.Books.Domain.Models;

namespace API.Domains.Books.Domain.Repositories;

public interface IBooksRepository
{
    Task AddBook(BookDTO bookDto);
    Task RemoveBook(string bookId);
    Task<BookModel> GetBookById(string bookId);
    Task<List<BookModel>> GetBooks();
}