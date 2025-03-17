using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Repositories;
using API.Domains.Mail.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Domains.Books.Controller;

[ApiController]
[Route("api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorsRepository _authorsRepository;
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;

    public AuthorsController(IAuthorsRepository authorsRepository, IMailService mailService, IMapper mapper)
    {
        _authorsRepository = authorsRepository ?? throw new ArgumentNullException(nameof(authorsRepository));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    [SwaggerResponse(200, "The list of authors", typeof(List<AuthorDto>))]
    public async Task<ActionResult<List<AuthorDto>>> GetAuthors([FromQuery] bool includeBooks = false)
    {
        _mailService.Send("GetAuthors", "That's him!");

        var authors = await _authorsRepository.GetAuthors(includeBooks);

        if (authors.Capacity == 0) return NoContent();

        return Ok(_mapper.Map<List<AuthorDto>>(authors));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<AuthorDto>> GetAuthorById(int id)
    {
        var book = await _authorsRepository.GetAuthor(id.ToString());

        if (book == null) return NoContent();

        return Ok(_mapper.Map<AuthorDto>(book));
    }
}