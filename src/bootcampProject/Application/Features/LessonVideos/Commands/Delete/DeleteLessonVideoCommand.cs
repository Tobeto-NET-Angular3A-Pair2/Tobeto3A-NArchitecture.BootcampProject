using Application.Features.LessonVideos.Constants;
using Application.Features.LessonVideos.Constants;
using Application.Features.LessonVideos.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.LessonVideos.Constants.LessonVideosOperationClaims;

namespace Application.Features.LessonVideos.Commands.Delete;

public class DeleteLessonVideoCommand
    : IRequest<DeletedLessonVideoResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, LessonVideosOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLessonVideos"];

    public class DeleteLessonVideoCommandHandler : IRequestHandler<DeleteLessonVideoCommand, DeletedLessonVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonVideoRepository _lessonVideoRepository;
        private readonly LessonVideoBusinessRules _lessonVideoBusinessRules;

        public DeleteLessonVideoCommandHandler(
            IMapper mapper,
            ILessonVideoRepository lessonVideoRepository,
            LessonVideoBusinessRules lessonVideoBusinessRules
        )
        {
            _mapper = mapper;
            _lessonVideoRepository = lessonVideoRepository;
            _lessonVideoBusinessRules = lessonVideoBusinessRules;
        }

        public async Task<DeletedLessonVideoResponse> Handle(
            DeleteLessonVideoCommand request,
            CancellationToken cancellationToken
        )
        {
            LessonVideo? lessonVideo = await _lessonVideoRepository.GetAsync(
                predicate: lv => lv.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _lessonVideoBusinessRules.LessonVideoShouldExistWhenSelected(lessonVideo);

            await _lessonVideoRepository.DeleteAsync(lessonVideo!);

            DeletedLessonVideoResponse response = _mapper.Map<DeletedLessonVideoResponse>(lessonVideo);
            return response;
        }
    }
}
