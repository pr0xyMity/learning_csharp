using API.Domains.Books.Domain.Models;

namespace API.Domains.Books.Domain.Repositories;

public interface IBooksRepository
{
    Task<BookModel> AddBook(BookModel bookModel);
    Task RemoveBook(string bookId);
    Task<BookModel?> GetBookById(string bookId);
    Task<List<BookModel>> GetBooks();
}