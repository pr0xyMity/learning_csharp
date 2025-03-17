using API.Domains.Books.Data.DataSources;
using API.Domains.Books.Domain;
using API.Domains.Books.Domain.Models;
using API.Domains.Books.Domain.Repositories;
using AutoMapper;

namespace API.Domains.Books.Data.Repositories;

public class AuthorsRepository : IAuthorsRepository
{
    private readonly IAuthorsDatasource _authorsDatasource;
    private readonly IMapper _mapper;


    public AuthorsRepository(IMapper mapper, IAuthorsDatasource authorsDatasource)
    {
        _authorsDatasource = authorsDatasource ?? throw new ArgumentNullException(nameof(authorsDatasource));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task AddAuthor(AuthorDto authorDto)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAuthor(string authorId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<AuthorModel>> GetAuthors(bool includeBooks)
    {
        List<AuthorModel> authors;

        if (includeBooks)
            authors = await _authorsDatasource.GetAuthorsWithBooks();
        else
            authors = await _authorsDatasource.GetAuthorsWithoutBooks();

        if (authors.Count == 0) return new List<AuthorModel>();

        return authors;
    }

    public async Task<AuthorModel?> GetAuthor(string authorId)
    {
        var author = await _authorsDatasource.GetAuthor(authorId);

        if (author == null) return null;

        return _mapper.Map<AuthorModel>(author);
    }
}