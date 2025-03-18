using API.Domains.Books.Domain.Models;

namespace API.Domains.Books.Domain.Repositories;

public interface IAuthorsRepository
{
    Task<AuthorModel> AddAuthor(AuthorForCreationDto authorDto);
    Task RemoveAuthor(string authorId);
    Task<List<AuthorModel>> GetAuthors(bool includeBooks);

    Task<List<AuthorModel>> GetAuthorsByIds(List<string> authorIds);
    Task<AuthorModel?> GetAuthor(string authorId);
}