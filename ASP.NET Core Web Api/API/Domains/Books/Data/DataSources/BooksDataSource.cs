using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Domains.Books.Data.DataSources;

public interface IBooksDatasource
{
    /// <summary>
    ///     Get single book details with the book ID.
    /// </summary>
    Task<Book?> GetBookById(string bookId);

    /// <summary>
    ///     Get whole list of available books.
    /// </summary>
    Task<List<Book>> GetBooks();

    /// <summary>
    ///     Create single book and return created book.
    /// </summary>
    Task<Book> AddBook(BookModel bookModel);
}

public class BooksDataSource : IBooksDatasource
{
    private readonly BookContext _bookContext;

    public BooksDataSource(BookContext bookContext)
    {
        _bookContext = bookContext ?? throw new ArgumentNullException(nameof(bookContext));
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _bookContext.Books
            .Include(book => book.Authors)
            .Select(book => new Book
            {
                Id = book.Id,
                Title = book.Title,
                Authors = book.Authors.Select(author => new Author
                {
                    Id = author.Id,
                    Name = author.Name
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<Book> AddBook(BookModel bookModel)
    {
        var entity = new Book
        {
            Title = bookModel.Title,
            Authors = await _bookContext.Authors
                .Where(a => bookModel.AuthorsIds.Contains(a.Id))
                .ToListAsync()
        };

        _bookContext.Books.Add(entity);
        await _bookContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Book?> GetBookById(string bookId)
    {
        return await _bookContext.Books.Where(book => book.Id == bookId)
            .Select(book => new Book
            {
                Id = book.Id,
                Title = book.Title,
                Authors = book.Authors.Select(author => new Author
                {
                    Id = author.Id,
                    Name = author.Name
                }).ToList()
            })
            .FirstOrDefaultAsync();
    }
}