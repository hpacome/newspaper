namespace newspaper.repository.Entities;

public class Author
{
    public Author(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    // Property Id of type GUID with getters and setters
    public Guid Id { get; set; }

    // Property Name of type GUID with getters and setters
    public string Name { get; set; }

    // Property Email of type GUID with getters and setters
    public string Email { get; set; }
}
