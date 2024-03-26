namespace Domain.Entities;

public class Employee : User
{
    public string Position { get; set; }

    public Employee(
        Guid id,
        string userName,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string nationalIdentity,
        string email,
        byte[] passwordHash,
        byte[] passwordSalt,
        string position
    )
    {
        Id = id;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        Position = position;
    }

    public Employee() { }
}
