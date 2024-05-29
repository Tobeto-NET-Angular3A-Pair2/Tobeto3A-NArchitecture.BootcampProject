using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Contacts.Queries.GetList;

public class GetListContactListItemDto : IDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
}
