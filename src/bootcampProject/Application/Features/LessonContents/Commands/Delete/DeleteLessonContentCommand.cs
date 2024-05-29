using Application.Features.LessonContents.Constants;
using Application.Features.LessonContents.Constants;
using Application.Features.LessonContents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.LessonContents.Constants.LessonContentsOperationClaims;

namespace Application.Features.LessonContents.Commands.Delete;

public class DeleteLessonContentCommand
    : IRequest<DeletedLessonContentResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int LessonId { get; set; }

    public string[] Roles => [Admin, Write, LessonContentsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLessonContents"];

    public class DeleteLessonContentCommandHandler : IRequestHandler<DeleteLessonContentCommand, DeletedLessonContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonContentRepository _lessonContentRepository;
        private readonly LessonContentBusinessRules _lessonContentBusinessRules;

        public DeleteLessonContentCommandHandler(
            IMapper mapper,
            ILessonContentRepository lessonContentRepository,
            LessonContentBusinessRules lessonContentBusinessRules
        )
        {
            _mapper = mapper;
            _lessonContentRepository = lessonContentRepository;
            _lessonContentBusinessRules = lessonContentBusinessRules;
        }

        public async Task<DeletedLessonContentResponse> Handle(
            DeleteLessonContentCommand request,
            CancellationToken cancellationToken
        )
        {
            LessonContent? lessonContent = await _lessonContentRepository.GetAsync(
                predicate: lc => lc.LessonId == request.LessonId,
                cancellationToken: cancellationToken
            );
            await _lessonContentBusinessRules.LessonContentShouldExistWhenSelected(lessonContent);

            await _lessonContentRepository.DeleteAsync(lessonContent!, permanent: true);

            DeletedLessonContentResponse response = _mapper.Map<DeletedLessonContentResponse>(lessonContent);
            return response;
        }
    }
}
