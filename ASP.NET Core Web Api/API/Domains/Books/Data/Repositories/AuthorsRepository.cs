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

    public async Task<AuthorModel> AddAuthor(AuthorForCreationDto authorCreationDto)
    {
        var author = _mapper.Map<Author>(authorCreationDto);
        var createdAuthor = await _authorsDatasource.AddAuthor(author);
        return _mapper.Map<AuthorModel>(createdAuthor);
    }

    public async Task RemoveAuthor(string authorId)
    {
        await _authorsDatasource.RemoveAuthor(authorId);
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

    public async Task<List<AuthorModel>> GetAuthorsByIds(List<string> authorIds)
    {
        var authors = await _authorsDatasource.GetAuthorsByIds(authorIds);
        return _mapper.Map<List<AuthorModel>>(authors);
    }

    public async Task<AuthorModel?> GetAuthor(string authorId)
    {
        var author = await _authorsDatasource.GetAuthor(authorId);

        if (author == null) return null;

        return _mapper.Map<AuthorModel>(author);
    }
}