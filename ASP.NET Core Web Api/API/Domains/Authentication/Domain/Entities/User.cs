using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domains.Books;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(64)]
    public string UserName { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}