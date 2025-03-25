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
    private readonly IAuthorsRepository _authorsRepository;
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;

    public AuthorsController(IAuthorsRepository authorsRepository, IMailService mailService, IMapper mapper)
    {
        _authorsRepository = authorsRepository ?? throw new ArgumentNullException(nameof(authorsRepository));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpDelete("{authorId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> RemoveAuthor(string authorId)
    {
        _mailService.Send("Remove Author", "No more with us!");

        await _authorsRepository.RemoveAuthor(authorId);

        return NoContent();
    }

    // [HttpPost]
    // [Route("/api/authors/{authorId}/books")]
    // [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status201Created)]
    // public async Task<ActionResult<AuthorDto>> AddBooksToAuthor(AuthorForCreationDto authorForCreationDto)
    // {
    //     _mailService.Send("CreateAuthors", "You want to write huh?");
    //     var authorToReturn = await _authorsRepository.AddAuthor(authorForCreationDto);
    //     var uri = Url.Action(nameof(GetAuthorById), new { id = authorToReturn.Id });
    //     return Created(uri, authorToReturn);
    // }

    [HttpPut("{authorId}")]
    [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status200OK)]
    public async Task<ActionResult> UpdateAuthor(string authorId, AuthorForUpdateDto authorForUpdateDto)
    {
        // Create a full update entity for the Author Entity.

        _mailService.Send("Update the whole entity", "Lets revisit this and change, huh?");

        var authorToReturn = await _authorsRepository.UpdateAuthor(authorForUpdateDto);

        return Ok(_mapper.Map<AuthorDto>(authorToReturn));
    }


    [HttpPost]
    [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<AuthorDto>> CreateAuthor(AuthorForCreationDto authorForCreationDto)
    {
        _mailService.Send("CreateAuthors", "You want to write huh?");

        var authorToReturn = await _authorsRepository.AddAuthor(authorForCreationDto);

        var uri = Url.Action(nameof(GetAuthorById), new { id = authorToReturn.Id });

        return Created(uri, authorToReturn);
    }

    [HttpGet]
    [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AuthorDto>>> GetAuthors([FromQuery] bool includeBooks = false)
    {
        _mailService.Send("GetAuthors", "That's him!");

        var authors = await _authorsRepository.GetAuthors(includeBooks);

        if (authors.Capacity == 0) return NoContent();

        return Ok(_mapper.Map<List<AuthorDto>>(authors));
    }

    [HttpGet("{authorId}")]
    [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<AuthorDto>> GetAuthorById(string authorId)
    {
        var book = await _authorsRepository.GetAuthor(authorId);

        if (book == null) return NoContent();

        return Ok(_mapper.Map<AuthorDto>(book));
    }
}