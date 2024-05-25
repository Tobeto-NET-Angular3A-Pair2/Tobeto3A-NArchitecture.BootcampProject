using NArchitecture.Core.Application.Responses;

namespace Application.Features.Contacts.Queries.GetById;

public class GetByIdContactResponse : IResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
}
