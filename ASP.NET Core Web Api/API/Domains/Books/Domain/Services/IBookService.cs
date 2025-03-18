using API.Domains.Books.Domain.Models;

public interface IBooksService
{
    Task<BookModel> AddBook(BookModel bookModel);
    Task<BookModel?> GetBookById(string bookId);
    Task<List<BookModel>> GetBooks();
}