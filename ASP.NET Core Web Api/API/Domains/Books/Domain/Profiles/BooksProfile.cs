using API.Domains.Books.Domain.Models;
using AutoMapper;

namespace API.Domains.Books.Domain.Profiles;

public class BooksProfile : Profile
{
    public BooksProfile()
    {
        CreateMap<Book, BookModel>();
        CreateMap<BookModel, BookDTO>();
    }
}