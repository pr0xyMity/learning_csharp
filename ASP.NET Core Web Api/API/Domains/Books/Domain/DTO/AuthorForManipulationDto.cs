using System.ComponentModel.DataAnnotations;

namespace API.Domains.Books.Domain;

public abstract class AuthorForManipulationDto
{
    [Required]
    [MaxLength(50)]
    [MinLength(2)]
    public required string Name { get; set; }

    [MaxLength(50)] [MinLength(2)] public string? Email { get; set; }
}