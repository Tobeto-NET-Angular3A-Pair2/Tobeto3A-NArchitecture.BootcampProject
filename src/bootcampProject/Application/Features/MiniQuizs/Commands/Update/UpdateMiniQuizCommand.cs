using Application.Features.MiniQuizs.Constants;
using Application.Features.MiniQuizs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MiniQuizs.Constants.MiniQuizsOperationClaims;

namespace Application.Features.MiniQuizs.Commands.Update;

public class UpdateMiniQuizCommand : IRequest<UpdatedMiniQuizResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public int LessonId { get; set; }

    public string[] Roles => [Admin, Write, MiniQuizsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMiniQuizs"];

    public class UpdateMiniQuizCommandHandler : IRequestHandler<UpdateMiniQuizCommand, UpdatedMiniQuizResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMiniQuizRepository _miniQuizRepository;
        private readonly MiniQuizBusinessRules _miniQuizBusinessRules;

        public UpdateMiniQuizCommandHandler(IMapper mapper, IMiniQuizRepository miniQuizRepository,
                                         MiniQuizBusinessRules miniQuizBusinessRules)
        {
            _mapper = mapper;
            _miniQuizRepository = miniQuizRepository;
            _miniQuizBusinessRules = miniQuizBusinessRules;
        }

        public async Task<UpdatedMiniQuizResponse> Handle(UpdateMiniQuizCommand request, CancellationToken cancellationToken)
        {
            MiniQuiz? miniQuiz = await _miniQuizRepository.GetAsync(predicate: mq => mq.Id == request.Id, cancellationToken: cancellationToken);
            await _miniQuizBusinessRules.MiniQuizShouldExistWhenSelected(miniQuiz);
            miniQuiz = _mapper.Map(request, miniQuiz);

            await _miniQuizRepository.UpdateAsync(miniQuiz!);

            UpdatedMiniQuizResponse response = _mapper.Map<UpdatedMiniQuizResponse>(miniQuiz);
            return response;
        }
    }
}