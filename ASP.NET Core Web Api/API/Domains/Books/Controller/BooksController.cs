using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Domains.Books.Controller;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
   private readonly IBooksRepository _booksRepository;

   public BooksController(IBooksRepository booksRepository)
   {
       this._booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
   }

   [HttpGet]
   [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
   public async Task<ActionResult<List<Book>>> GetBooks()
   {
       List<Book?> books = await _booksRepository.getBooks();
       if (books.Count() == 0)
       {
           return NoContent();
       }
       return Ok(books);
   }
   
   [HttpGet("{id:guid}")]
   [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
   public async Task<ActionResult<Book>> GetBookById(Guid id)
   {
       Book? book = await _booksRepository.getBookById(id);
       if (book == null)
       {
           return NoContent();
       }
       return Ok(book);
   }
}