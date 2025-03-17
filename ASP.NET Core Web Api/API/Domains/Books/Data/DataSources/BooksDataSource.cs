using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Domains.Books.Data.DataSources;

public interface IBooksDatasource
{
    /// <summary>
    ///     Get single book details with the book ID.
    /// </summary>
    Task<BookModel?> GetBookById(string bookId);

    /// <summary>
    ///     Get whole list of available books.
    /// </summary>
    Task<List<BookModel>> GetBooks();
}

public class BooksDataSource : IBooksDatasource
{
    private readonly BookContext _bookContext;

    public BooksDataSource(BookContext bookContext)
    {
        _bookContext = bookContext ?? throw new ArgumentNullException(nameof(bookContext));
    }

    public async Task<BookModel?> GetBookById(string bookId)
    {
        return await _bookContext.Books.Where(book => book.Id == bookId)
            .Select(book => new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Authors = book.Authors.Select(author => new AuthorModel
                {
                    Id = author.Id,
                    Name = author.Name
                }).ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<BookModel>> GetBooks()
    {
        return await _bookContext.Books
            .Include(book => book.Authors)
            .Select(book => new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Authors = book.Authors.Select(author => new AuthorModel
                {
                    Id = author.Id,
                    Name = author.Name
                }).ToList()
            })
            .ToListAsync();
    }
}