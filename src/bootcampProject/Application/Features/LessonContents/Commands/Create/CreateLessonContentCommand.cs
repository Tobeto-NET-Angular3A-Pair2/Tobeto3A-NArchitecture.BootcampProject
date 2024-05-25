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

namespace Application.Features.LessonContents.Commands.Create;

public class CreateLessonContentCommand
    : IRequest<CreatedLessonContentResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public string Text { get; set; }
    public int LessonId { get; set; }
    public string VideoUrl { get; set; }

    public string[] Roles => [Admin, Write, LessonContentsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetLessonContents"];

    public class CreateLessonContentCommandHandler : IRequestHandler<CreateLessonContentCommand, CreatedLessonContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonContentRepository _lessonContentRepository;
        private readonly LessonContentBusinessRules _lessonContentBusinessRules;

        public CreateLessonContentCommandHandler(
            IMapper mapper,
            ILessonContentRepository lessonContentRepository,
            LessonContentBusinessRules lessonContentBusinessRules
        )
        {
            _mapper = mapper;
            _lessonContentRepository = lessonContentRepository;
            _lessonContentBusinessRules = lessonContentBusinessRules;
        }

        public async Task<CreatedLessonContentResponse> Handle(
            CreateLessonContentCommand request,
            CancellationToken cancellationToken
        )
        {
            LessonContent lessonContent = _mapper.Map<LessonContent>(request);

            await _lessonContentRepository.AddAsync(lessonContent);

            CreatedLessonContentResponse response = _mapper.Map<CreatedLessonContentResponse>(lessonContent);
            return response;
        }
    }
}
