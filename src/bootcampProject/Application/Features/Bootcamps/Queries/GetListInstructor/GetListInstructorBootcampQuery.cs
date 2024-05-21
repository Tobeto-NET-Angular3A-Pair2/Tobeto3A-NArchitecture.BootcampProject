using Application.Features.Bootcamps.Constants;
using Application.Features.Instructors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Bootcamps.Constants.BootcampsOperationClaims;

namespace Application.Features.Bootcamps.Queries.GetList;

public class GetListInstructorBootcampQuery : IRequest<GetListResponse<GetListInstructorBootcampListItemDto>>, ISecuredRequest
{
    public Guid InstructorId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles =>
        new[]
        {
            BootcampsOperationClaims.Admin,
            BootcampsOperationClaims.Write,
            BootcampsOperationClaims.Create,
            InstructorsOperationClaims.Admin
        };

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListInstructorBootcamps({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetInstructorBootcamps";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListInstructorBootcampQueryHandler
        : IRequestHandler<GetListInstructorBootcampQuery, GetListResponse<GetListInstructorBootcampListItemDto>>
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IMapper _mapper;

        public GetListInstructorBootcampQueryHandler(IBootcampRepository bootcampRepository, IMapper mapper)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListInstructorBootcampListItemDto>> Handle(
            GetListInstructorBootcampQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Bootcamp> bootcamps = await _bootcampRepository.GetListAsync(
                predicate: b => b.InstructorId == request.InstructorId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );
            Console.WriteLine($"Retrieved Bootcamps Count: {bootcamps.Items.Count}");

            GetListResponse<GetListInstructorBootcampListItemDto> response = _mapper.Map<
                GetListResponse<GetListInstructorBootcampListItemDto>
            >(bootcamps);
            return response;
        }
    }
}
