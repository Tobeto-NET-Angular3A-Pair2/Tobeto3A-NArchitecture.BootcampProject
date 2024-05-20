using Application.Features.LessonContents.Constants;
using Application.Features.LessonContents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.LessonContents.Constants.LessonContentsOperationClaims;

namespace Application.Features.LessonContents.Commands.Update;

public class UpdateLessonContentCommand : IRequest<UpdatedLessonContentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int LessonId { get; set; }

    public string[] Roles => [Admin, Write, LessonContentsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLessonContents"];

    public class UpdateLessonContentCommandHandler : IRequestHandler<UpdateLessonContentCommand, UpdatedLessonContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonContentRepository _lessonContentRepository;
        private readonly LessonContentBusinessRules _lessonContentBusinessRules;

        public UpdateLessonContentCommandHandler(IMapper mapper, ILessonContentRepository lessonContentRepository,
                                         LessonContentBusinessRules lessonContentBusinessRules)
        {
            _mapper = mapper;
            _lessonContentRepository = lessonContentRepository;
            _lessonContentBusinessRules = lessonContentBusinessRules;
        }

        public async Task<UpdatedLessonContentResponse> Handle(UpdateLessonContentCommand request, CancellationToken cancellationToken)
        {
            LessonContent? lessonContent = await _lessonContentRepository.GetAsync(predicate: lc => lc.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonContentBusinessRules.LessonContentShouldExistWhenSelected(lessonContent);
            lessonContent = _mapper.Map(request, lessonContent);

            await _lessonContentRepository.UpdateAsync(lessonContent!);

            UpdatedLessonContentResponse response = _mapper.Map<UpdatedLessonContentResponse>(lessonContent);
            return response;
        }
    }
}