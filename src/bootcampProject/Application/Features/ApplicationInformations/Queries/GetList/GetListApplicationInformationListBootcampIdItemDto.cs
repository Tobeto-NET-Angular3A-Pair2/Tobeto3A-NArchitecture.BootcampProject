using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ApplicationInformations.Queries.GetList;

public class GetListApplicationInformationListBootcampIdItemDto : IDto
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public int BootcampId { get; set; }
}
