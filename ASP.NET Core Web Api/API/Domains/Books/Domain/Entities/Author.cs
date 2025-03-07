namespace API.Domains.Books.Domain;

public class Author
{
    String FirstName { get; set; }
    String LastName { get; set; }
    String? Email { get; set; }

    Author(string firstName, string lastName, string? email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}