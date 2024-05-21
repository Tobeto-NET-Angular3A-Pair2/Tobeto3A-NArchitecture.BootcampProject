using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Contact : Entity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Message { get; set; }

    public Contact() { }

    public Contact(int id, string firstName, string lastName, string email, string phoneNumber, string message)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Message = message;
    }
}
