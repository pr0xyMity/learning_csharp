namespace API.Domains.Books.Domain.Repositories;

public interface IBooksRepository
{
    void addBook(Book book);
    void removeBook(Book book);
    void getBookById(string bookId);
    void getBooks();
}