using API.Domains.Books.Data.DataSources;
using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Models;
using API.Domains.Books.Domain.Repositories;
using AutoMapper;

namespace API.Domains.Books.Data.Repositories;

public class BooksRepository : IBooksRepository
{
    private readonly IBooksDatasource _booksDatasource;
    private readonly IMapper _mapper;


    public BooksRepository(IBooksDatasource booksDatasource, IMapper mapper)
    {
        _booksDatasource = booksDatasource ?? throw new ArgumentNullException(nameof(booksDatasource));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public Task AddBook(BookDTO bookDto)
    {
        throw new NotImplementedException();
    }

    public Task RemoveBook(string bookId)
    {
        throw new NotImplementedException();
    }

    public async Task<BookModel?> GetBookById(string bookId)
    {
        var book = await _booksDatasource.GetBook(bookId);

        if (book == null) return null;

        return _mapper.Map<BookModel>(book);
    }

    public async Task<List<BookModel>> GetBooks()
    {
        var books = await _booksDatasource.GetBooks();

        if (books.Count == 0) return new List<BookModel>();

        return _mapper.Map<List<BookModel>>(books);
    }

    public Task AddAuthor(AuthorDTO authorDto)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAuthor(string authorId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<AuthorModel>> GetAuthors(bool includeBooks)
    {
        var authors = await _booksDatasource.GetAuthors();

        if (authors.Count == 0) return new List<AuthorModel>();

        return _mapper.Map<List<AuthorModel>>(authors);
    }

    public async Task<AuthorModel?> GetAuthor(string authorId)
    {
        var author = await _booksDatasource.GetAuthor(authorId);

        if (author == null) return null;

        return _mapper.Map<AuthorModel>(author);
    }
}