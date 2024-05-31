using Application.Features.Applicants.Constants;
using Application.Features.Bootcamps.Constants;
using Application.Features.Instructors.Constants;
using Application.Features.LessonContents.Constants;
using Application.Features.Lessons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Lessons.Constants.LessonsOperationClaims;

namespace Application.Features.Lessons.Queries.GetList;

public class GetListLessonQuery : IRequest<GetListResponse<GetListLessonListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public int BootcampId { get; set; }

    public string[] Roles =>
       new[]
       {
            LessonContentsOperationClaims.Admin,
            LessonContentsOperationClaims.Write,
            LessonContentsOperationClaims.Create,
            InstructorsOperationClaims.Admin,
            ApplicantsOperationClaims.Admin
       };

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListLessons({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetLessons";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLessonQueryHandler : IRequestHandler<GetListLessonQuery, GetListResponse<GetListLessonListItemDto>>
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public GetListLessonQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLessonListItemDto>> Handle(
            GetListLessonQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Lesson> lessons = await _lessonRepository.GetListAsync(
                 predicate: b => b.BootcampId == request.BootcampId,
                 index: request.PageRequest.PageIndex,
                 size: request.PageRequest.PageSize,
                 cancellationToken: cancellationToken
            );
           

            GetListResponse<GetListLessonListItemDto> response = _mapper.Map<GetListResponse<GetListLessonListItemDto>>(lessons);
            return response;
        }
    }
}
