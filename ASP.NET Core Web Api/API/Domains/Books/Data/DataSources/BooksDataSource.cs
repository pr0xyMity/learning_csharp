using API.Domains.Books.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Domains.Books.Data.DataSources;

public interface IBooksDatasource
{
    /// <summary>
    ///     Get single book details with the book ID.
    /// </summary>
    Task<Book?> GetBook(string bookId);

    /// <summary>
    ///     Get whole list of available books.
    /// </summary>
    Task<List<Book>> GetBooks();

    /// <summary>
    ///     Get single author details with the book ID.
    /// </summary>
    Task<Author?> GetAuthor(string authorId);

    /// <summary>
    ///     Get whole list of available authors.
    /// </summary>
    Task<List<Author>> GetAuthors();
}

public class BooksDataSource : IBooksDatasource
{
    private readonly BookContext _bookContext;

    public BooksDataSource(BookContext bookContext)
    {
        _bookContext = bookContext ?? throw new ArgumentNullException(nameof(bookContext));
    }

    public async Task<Book?> GetBook(string bookId)
    {
        return await _bookContext.Books.Where(book => book.Id == bookId).FirstOrDefaultAsync();
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _bookContext.Books.ToListAsync();
    }

    public async Task<Author?> GetAuthor(string authorId)
    {
        return await _bookContext.Authors.Where(author => author.Id == authorId).FirstOrDefaultAsync();
    }

    public async Task<List<Author>> GetAuthors()
    {
        return await _bookContext.Authors.ToListAsync();
    }
}