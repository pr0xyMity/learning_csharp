using Microsoft.EntityFrameworkCore;

namespace API.Domains.Books.Domain;

public class BookInfoContext: DbContext
{ 
	public DbSet<Book> Books { get; set; }
	public DbSet<Author>  Authors { get; set; }
	
	public BookInfoContext(DbContextOptions<BookInfoContext> options)
		: base(options)
	{
	}
}