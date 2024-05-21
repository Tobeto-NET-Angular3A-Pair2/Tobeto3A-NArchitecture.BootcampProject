using Application.Features.LessonVideos.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.LessonVideos.Constants.LessonVideosOperationClaims;

namespace Application.Features.LessonVideos.Queries.GetList;

public class GetListLessonVideoQuery : IRequest<GetListResponse<GetListLessonVideoListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListLessonVideos({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetLessonVideos";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLessonVideoQueryHandler
        : IRequestHandler<GetListLessonVideoQuery, GetListResponse<GetListLessonVideoListItemDto>>
    {
        private readonly ILessonVideoRepository _lessonVideoRepository;
        private readonly IMapper _mapper;

        public GetListLessonVideoQueryHandler(ILessonVideoRepository lessonVideoRepository, IMapper mapper)
        {
            _lessonVideoRepository = lessonVideoRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLessonVideoListItemDto>> Handle(
            GetListLessonVideoQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<LessonVideo> lessonVideos = await _lessonVideoRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLessonVideoListItemDto> response = _mapper.Map<GetListResponse<GetListLessonVideoListItemDto>>(
                lessonVideos
            );
            return response;
        }
    }
}
