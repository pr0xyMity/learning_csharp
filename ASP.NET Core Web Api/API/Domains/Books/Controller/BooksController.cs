using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Repositories;
using API.Domains.Mail.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Domains.Books.Controller;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBooksRepository _booksRepository;
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;

    public BooksController(IBooksRepository booksRepository, IMailService mailService, IMapper mapper)
    {
        _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<BookDTO>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<BookDTO>>> GetBooks()
    {
        _mailService.Send("GetBooks", "Took the books!");

        var books = await _booksRepository.GetBooks();

        if (!books.Any()) return NoContent();
        return Ok(_mapper.Map<List<BookDTO>>(books));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BookDTO), StatusCodes.Status200OK)]
    public async Task<ActionResult<BookDTO>> GetBookById(string id)
    {
        var book = await _booksRepository.GetBookById(id);

        if (book == null) return NoContent();

        return Ok(_mapper.Map<BookDTO>(book));
    }
}