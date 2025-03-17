using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Domains.Books.Data.DataSources;

public interface IAuthorsDatasource
{
    /// <summary>
    ///     Get single author details with the books IDs.
    /// </summary>
    Task<AuthorModel?> GetAuthor(string authorId);

    /// <summary>
    ///     Get whole list of available authors with book ID and title.
    /// </summary>
    Task<List<AuthorModel>> GetAuthorsWithBooks();

    /// <summary>
    ///     Get whole list of available authors without book IDs.
    /// </summary>
    Task<List<AuthorModel>> GetAuthorsWithoutBooks();
}

public class AuthorsDataSource : IAuthorsDatasource
{
    private readonly BookContext _bookContext;

    public AuthorsDataSource(BookContext bookContext)
    {
        _bookContext = bookContext ?? throw new ArgumentNullException(nameof(bookContext));
    }

    public async Task<AuthorModel?> GetAuthor(string authorId)
    {
        return await _bookContext.Authors.Where(author => author.Id == authorId)
            .Include(author => author.Books)
            .Select(author => new AuthorModel
            {
                Id = author.Id,
                Name = author.Name,
                Books = author.Books.Select(book => new BookWithoutAuthorsModel
                {
                    Id = book.Id,
                    Title = book.Title
                }).ToList()
            }).FirstOrDefaultAsync();
        ;
    }

    public async Task<List<AuthorModel>> GetAuthorsWithoutBooks()
    {
        return await _bookContext.Authors
            .Select(author => new AuthorModel
            {
                Id = author.Id,
                Name = author.Name,
                Books = new List<BookWithoutAuthorsModel>()
            })
            .ToListAsync();
    }

    public async Task<List<AuthorModel>> GetAuthorsWithBooks()
    {
        return await _bookContext.Authors
            .Include(author => author.Books)
            .Select(author => new AuthorModel
            {
                Id = author.Id,
                Name = author.Name,
                Books = author.Books.Select(book => new BookWithoutAuthorsModel
                {
                    Id = book.Id,
                    Title = book.Title
                }).ToList()
            })
            .ToListAsync();
    }
}