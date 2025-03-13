using Microsoft.EntityFrameworkCore;

namespace API.Domains.Books.Domain;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasMany<Book>(a => a.Books)
            .WithMany(b => b.Authors)
            .UsingEntity(j => j.ToTable("AuthorBook"));

        modelBuilder.Entity<Book>()
            .HasMany<Author>(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity(j => j.ToTable("AuthorBook"));

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var authors = new List<Author>
        {
            new() { Id = "1", Name = "George Orwell" },
            new() { Id = "2", Name = "J.K. Rowling" },
            new() { Id = "3", Name = "J.R.R. Tolkien" }
        };

        var books = new List<Book>
        {
            new() { Id = "1", Title = "1984" },
            new() { Id = "2", Title = "Animal Farm" },
            new() { Id = "3", Title = "Harry Potter and the Philosopher's Stone" },
            new() { Id = "4", Title = "The Lord of the Rings" },
            new() { Id = "5", Title = "The Hobbit" }
        };

        modelBuilder.Entity<Author>().HasData(authors);
        modelBuilder.Entity<Book>().HasData(books);

        // Seed the many-to-many relationship
        modelBuilder.Entity("AuthorBook").HasData(
            new { AuthorsId = "1", BooksId = "1" },
            new { AuthorsId = "1", BooksId = "2" },
            new { AuthorsId = "2", BooksId = "3" },
            new { AuthorsId = "3", BooksId = "4" },
            new { AuthorsId = "3", BooksId = "5" }
        );
    }
}