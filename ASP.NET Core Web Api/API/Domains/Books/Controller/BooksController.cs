using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Models;
using API.Domains.Books.Domain.Repositories;
using API.Domains.Mail.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Domains.Books.Controller;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
   private readonly IBooksRepository _booksRepository;
   private readonly IMailService _mailService;

   public BooksController(IBooksRepository booksRepository, IMailService mailService)
   {
       this._booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
       this._mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
       
   }

   [HttpGet]
   [ProducesResponseType(typeof(List<BookDTO>), StatusCodes.Status200OK)]
   public async Task<ActionResult<List<BookDTO>>> GetBooks()
   {
       _mailService.Send("GetBooks", "Took the books!");
       
       List<BookModel> books = await _booksRepository.GetBooks();
       
       if (books.Count() == 0)
       {
           return NoContent();
       }
       return Ok(books);
   }
   
   [HttpGet("{id:guid}")]
   [ProducesResponseType(typeof(BookDTO), StatusCodes.Status200OK)]
   public async Task<ActionResult<BookDTO>> GetBookById(string id)
   {
       BookModel? book = await _booksRepository.GetBookById(id);
       
       if (book == null)
       {
           return NoContent();
       }

       BookDTO bookDto = new BookDTO(book.Id, book.Title, book.Author);

       return Ok(book);
   }
}