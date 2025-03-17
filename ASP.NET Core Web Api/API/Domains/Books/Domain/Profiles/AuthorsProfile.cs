using API.Domains.Books.Domain.Models;
using AutoMapper;

namespace API.Domains.Books.Domain.Profiles;

public class AuthorsProfile : Profile
{
    public AuthorsProfile()
    {
        CreateMap<Author, AuthorModel>();
        CreateMap<AuthorModel, AuthorDto>();
    }
}