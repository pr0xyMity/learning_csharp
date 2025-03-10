namespace API.Domains.Books.Domain;

public class Author
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }

    public Author(string firstName, string lastName, string? email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}