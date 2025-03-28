namespace API.Domains.Books;

public class User
{
    public User(
        int userId,
        string firstName,
        string lastName
    )
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
    }

    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}