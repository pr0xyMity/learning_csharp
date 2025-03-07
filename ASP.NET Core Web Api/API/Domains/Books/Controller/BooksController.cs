using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Domains.Books.Controller;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
   private readonly IBooksRepository booksRepository;

   public BooksController(IBooksRepository booksRepository)
   {
       this.booksRepository = booksRepository;
   }

   [HttpGet]
   public async Task<ActionResult<List<Book>>> GetBooks()
   {
       List<Book> books = await booksRepository.getBooks();
       if (books.Count() == 0)
       {
           return NoContent();
       }
       return Ok(books);
   }
   
   [HttpGet("{id:int}")]
   public async Task<ActionResult<Book>> GetBookById(int id)
   {
       Book book = await booksRepository.getBookById($"{id}");
       if (book == null)
       {
           return NoContent();
       }
       return Ok(book);
   }
}