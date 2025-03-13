using API.Domains.Books.Domain;

namespace API.Domains.Books.Data.DataSources;

public interface IBooksDatasource
{
    /// <summary>
    ///     Get single book details with the book ID.
    /// </summary>
    Task<Book?> GetBook(string bookId);

    /// <summary>
    ///     Get whole list of available books.
    /// </summary>
    Task<List<Book>> GetBooks();
}

public class BooksDataSource : IBooksDatasource
{
    public async Task<Book?> GetBook(string bookId)
    {
        await Task.Delay(1);
        return
            new Book
            {
                Id = bookId,
                Authors =
                [
                    new Author
                    {
                        Name = "Tony Montana"
                    }
                ]
            };
    }

    public async Task<List<Book>> GetBooks()
    {
        await Task.Delay(1);
        return
        [
            new Book
            {
                Id = "1",
                Authors =
                [
                    new Author
                    {
                        Name = "Tony Montana"
                    }
                ]
            },
            new Book
            {
                Id = "2",
                Authors =
                [
                    new Author
                    {
                        Name = "Marko Toro"
                    }
                ]
            }
        ];
    }
}