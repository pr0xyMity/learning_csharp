using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Models;
using API.Domains.Mail.Domain.Services;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Domains.Books.Controller;

// The Controller is responsible for
// Handling: HTTP and Input Validation
// KeyObjects: Dto (Data Transfer Object)
// Mapping: Dto => Model

[ApiController]
[Route("api/v{version:apiVersion}/books")]
[Authorize]
[ApiVersion("1")]
[ApiVersion("2")]
public class BooksController : ControllerBase
{
    private readonly IBooksService _booksService;
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;

    public BooksController(IMailService mailService, IMapper mapper,
        IBooksService booksService)
    {
        _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<BookDto>> AddBook(BookForCreationDto bookForCreationDto)
    {
        _mailService.Send("Create a book", "You want to write huh?");

        var bookModel = _mapper.Map<BookModel>(bookForCreationDto);

        var bookToReturn = await _booksService.AddBook(bookModel);

        var uri = Url.Action(nameof(GetBookById), new { id = bookToReturn.Id });

        return Created(uri, bookToReturn);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<BookDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<BookDto>>> GetBooks()
    {
        _mailService.Send("GetBooks", "Took the books!");

        var books = await _booksService.GetBooks();

        if (!books.Any()) return NoContent();
        return Ok(_mapper.Map<List<BookDto>>(books));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<BookDto>> GetBookById(int id)
    {
        _mailService.Send("GetBookById", "Took the specific book by Id!");

        var book = await _booksService.GetBookById(id.ToString());

        if (book == null) return NoContent();

        return Ok(_mapper.Map<BookDto>(book));
    }
}