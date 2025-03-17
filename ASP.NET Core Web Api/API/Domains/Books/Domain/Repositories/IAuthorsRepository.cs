using API.Domains.Books.Domain.Models;

namespace API.Domains.Books.Domain.Repositories;

public interface IAuthorsRepository
{
    Task AddAuthor(AuthorDto authorDto);
    Task RemoveAuthor(string authorId);
    Task<List<AuthorModel>> GetAuthors(bool includeBooks);
    Task<AuthorModel?> GetAuthor(string authorId);
}