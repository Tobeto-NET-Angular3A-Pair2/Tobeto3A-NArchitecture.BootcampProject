using Application.Features.LessonVideos.Constants;
using Application.Features.LessonVideos.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.LessonVideos.Constants.LessonVideosOperationClaims;

namespace Application.Features.LessonVideos.Commands.Create;

public class CreateLessonVideoCommand : IRequest<CreatedLessonVideoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Url { get; set; }
    public int LessonId { get; set; }

    public string[] Roles => [Admin, Write, LessonVideosOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLessonVideos"];

    public class CreateLessonVideoCommandHandler : IRequestHandler<CreateLessonVideoCommand, CreatedLessonVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonVideoRepository _lessonVideoRepository;
        private readonly LessonVideoBusinessRules _lessonVideoBusinessRules;

        public CreateLessonVideoCommandHandler(IMapper mapper, ILessonVideoRepository lessonVideoRepository,
                                         LessonVideoBusinessRules lessonVideoBusinessRules)
        {
            _mapper = mapper;
            _lessonVideoRepository = lessonVideoRepository;
            _lessonVideoBusinessRules = lessonVideoBusinessRules;
        }

        public async Task<CreatedLessonVideoResponse> Handle(CreateLessonVideoCommand request, CancellationToken cancellationToken)
        {
            LessonVideo lessonVideo = _mapper.Map<LessonVideo>(request);

            await _lessonVideoRepository.AddAsync(lessonVideo);

            CreatedLessonVideoResponse response = _mapper.Map<CreatedLessonVideoResponse>(lessonVideo);
            return response;
        }
    }
}