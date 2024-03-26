namespace Domain.Entities;

public class Instructor : User
{
    public string CompanyName { get; set; }

    public virtual ICollection<Bootcamp> Bootcamps { get; set; }

    public Instructor(
        Guid id,
        string userName,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string nationalIdentity,
        string email,
        byte[] passwordHash,
        byte[] passwordSalt,
        string companyName
    )
        : this()
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
        CompanyName = companyName;
    }

    public Instructor()
    {
        Bootcamps = new HashSet<Bootcamp>();
    }
}
