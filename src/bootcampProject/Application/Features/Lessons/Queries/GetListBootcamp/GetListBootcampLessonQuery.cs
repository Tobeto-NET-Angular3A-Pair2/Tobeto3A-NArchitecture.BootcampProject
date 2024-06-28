using Application.Features.Applicants.Constants;
using Application.Features.Bootcamps.Constants;
using Application.Features.Instructors.Constants;
using Application.Features.LessonContents.Constants;
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

public class GetListBootcampLessonQuery : IRequest<GetListResponse<GetListBootcampLessonItemDto>>, ISecuredRequest
{
    public int BootcampId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles =>
        new[]
        {
            LessonContentsOperationClaims.Admin,
            LessonContentsOperationClaims.Write,
            LessonContentsOperationClaims.Create,
            InstructorsOperationClaims.Admin,
            ApplicantsOperationClaims.Read
        };

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBootcampLesson({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetListBootcampLesson";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBootcampLessonQueryHandler
        : IRequestHandler<GetListBootcampLessonQuery, GetListResponse<GetListBootcampLessonItemDto>>
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public GetListBootcampLessonQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBootcampLessonItemDto>> Handle(
            GetListBootcampLessonQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Lesson> lessons = await _lessonRepository.GetListAsync(
                predicate: b => b.BootcampId == request.BootcampId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );
            Console.WriteLine($"Retrieved Bootcamps Count: {lessons.Items.Count}");

            GetListResponse<GetListBootcampLessonItemDto> response = _mapper.Map<GetListResponse<GetListBootcampLessonItemDto>>(
                lessons
            );
            return response;
        }
    }
}
