using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domains.Books.Domain;

public class AuthorDTO
{
    public string Id { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
}