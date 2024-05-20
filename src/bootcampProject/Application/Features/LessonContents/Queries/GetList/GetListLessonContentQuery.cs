using Application.Features.LessonContents.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.LessonContents.Constants.LessonContentsOperationClaims;

namespace Application.Features.LessonContents.Queries.GetList;

public class GetListLessonContentQuery : IRequest<GetListResponse<GetListLessonContentListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListLessonContents({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetLessonContents";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLessonContentQueryHandler : IRequestHandler<GetListLessonContentQuery, GetListResponse<GetListLessonContentListItemDto>>
    {
        private readonly ILessonContentRepository _lessonContentRepository;
        private readonly IMapper _mapper;

        public GetListLessonContentQueryHandler(ILessonContentRepository lessonContentRepository, IMapper mapper)
        {
            _lessonContentRepository = lessonContentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLessonContentListItemDto>> Handle(GetListLessonContentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LessonContent> lessonContents = await _lessonContentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLessonContentListItemDto> response = _mapper.Map<GetListResponse<GetListLessonContentListItemDto>>(lessonContents);
            return response;
        }
    }
}