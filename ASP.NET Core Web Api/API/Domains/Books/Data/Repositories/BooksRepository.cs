using API.Domains.Books.Data.DataSources;
using API.Domains.Books.Domain.Models;
using API.Domains.Books.Domain.Repositories;
using AutoMapper;

namespace API.Domains.Books.Data.Repositories;

public class BooksRepository : IBooksRepository
{
    private readonly IBooksDatasource _booksDatasource;
    private readonly IMapper _mapper;


    public BooksRepository(IBooksDatasource booksDatasource, IMapper mapper, IAuthorsDatasource authorsDatasource)
    {
        _booksDatasource = booksDatasource ?? throw new ArgumentNullException(nameof(booksDatasource));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<BookModel> AddBook(BookModel bookModel)
    {
        var createdBook = await _booksDatasource.AddBook(bookModel);
        return _mapper.Map<BookModel>(createdBook);
    }

    public Task RemoveBook(string bookId)
    {
        throw new NotImplementedException();
    }

    public async Task<BookModel?> GetBookById(string bookId)
    {
        var book = await _booksDatasource.GetBookById(bookId);

        if (book == null) return null;

        return _mapper.Map<BookModel>(book);
    }

    public async Task<List<BookModel>> GetBooks()
    {
        var books = await _booksDatasource.GetBooks();

        if (books.Count == 0) return new List<BookModel>();

        return _mapper.Map<List<BookModel>>(books);
    }
}