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

namespace Application.Features.LessonVideos.Commands.Update;

public class UpdateLessonVideoCommand : IRequest<UpdatedLessonVideoResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Url { get; set; }
    public int LessonId { get; set; }

    public string[] Roles => [Admin, Write, LessonVideosOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLessonVideos"];

    public class UpdateLessonVideoCommandHandler : IRequestHandler<UpdateLessonVideoCommand, UpdatedLessonVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonVideoRepository _lessonVideoRepository;
        private readonly LessonVideoBusinessRules _lessonVideoBusinessRules;

        public UpdateLessonVideoCommandHandler(IMapper mapper, ILessonVideoRepository lessonVideoRepository,
                                         LessonVideoBusinessRules lessonVideoBusinessRules)
        {
            _mapper = mapper;
            _lessonVideoRepository = lessonVideoRepository;
            _lessonVideoBusinessRules = lessonVideoBusinessRules;
        }

        public async Task<UpdatedLessonVideoResponse> Handle(UpdateLessonVideoCommand request, CancellationToken cancellationToken)
        {
            LessonVideo? lessonVideo = await _lessonVideoRepository.GetAsync(predicate: lv => lv.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonVideoBusinessRules.LessonVideoShouldExistWhenSelected(lessonVideo);
            lessonVideo = _mapper.Map(request, lessonVideo);

            await _lessonVideoRepository.UpdateAsync(lessonVideo!);

            UpdatedLessonVideoResponse response = _mapper.Map<UpdatedLessonVideoResponse>(lessonVideo);
            return response;
        }
    }
}