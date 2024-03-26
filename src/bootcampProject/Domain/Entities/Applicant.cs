namespace Domain.Entities;

public class Applicant : User
{
    public string About { get; set; }

    public virtual ICollection<ApplicationInformation>? Applications { get; set; }
    public virtual Blacklist? Blacklist { get; set; }

    public Applicant(
        Guid id,
        string userName,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string nationalIdentity,
        string email,
        byte[] passwordHash,
        byte[] passwordSalt,
        string about
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
        About = about;
    }

    public Applicant()
    {
        Applications = new HashSet<ApplicationInformation>();
    }
}
