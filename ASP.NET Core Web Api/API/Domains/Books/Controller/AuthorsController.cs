using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Repositories;
using API.Domains.Mail.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Domains.Books.Controller;

[ApiController]
[Route("api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly IBooksRepository _booksRepository;
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;

    public AuthorsController(IBooksRepository booksRepository, IMailService mailService, IMapper mapper)
    {
        _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<AuthorWithoutBooksDTO>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AuthorWithoutBooksDTO>>> GetAuthors()
    {
        _mailService.Send("GetAuthors", "That's him!");

        var authors = await _booksRepository.GetAuthors(false);

        if (authors.Capacity == 0) return NoContent();

        return Ok(_mapper.Map<List<AuthorWithoutBooksDTO>>(authors));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AuthorDTO), StatusCodes.Status200OK)]
    public async Task<ActionResult<AuthorDTO>> GetAuthorById(string id)
    {
        var book = await _booksRepository.GetBookById(id);

        if (book == null) return NoContent();

        return Ok(_mapper.Map<AuthorDTO>(book));
    }
}