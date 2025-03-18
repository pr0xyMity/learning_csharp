using API.Domains.Books.Domain.Models;
using API.Domains.Books.Domain.Repositories;

namespace API.Domains.Books.Data.Services;

public class BooksService : IBooksService
{
    private readonly IAuthorsRepository _authorsRepository;
    private readonly IBooksRepository _booksRepository;

    public BooksService(IBooksRepository booksRepository, IAuthorsRepository authorsRepository)
    {
        _booksRepository = booksRepository;
        _authorsRepository = authorsRepository;
    }

    public async Task<BookModel> AddBook(BookModel model)
    {
        var authors = await _authorsRepository.GetAuthorsByIds(model.AuthorsIds.ToList());

        if (authors.Count != model.AuthorsIds.Count)
            throw new InvalidOperationException("Invalid author IDs");

        return await _booksRepository.AddBook(model);
    }

    public async Task<BookModel?> GetBookById(string bookId)
    {
        return await _booksRepository.GetBookById(bookId);
    }

    public async Task<List<BookModel>> GetBooks()
    {
        return await _booksRepository.GetBooks();
    }
}