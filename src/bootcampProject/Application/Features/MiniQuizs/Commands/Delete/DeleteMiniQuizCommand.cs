using Application.Features.MiniQuizs.Constants;
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

namespace Application.Features.MiniQuizs.Commands.Delete;

public class DeleteMiniQuizCommand : IRequest<DeletedMiniQuizResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, MiniQuizsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMiniQuizs"];

    public class DeleteMiniQuizCommandHandler : IRequestHandler<DeleteMiniQuizCommand, DeletedMiniQuizResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMiniQuizRepository _miniQuizRepository;
        private readonly MiniQuizBusinessRules _miniQuizBusinessRules;

        public DeleteMiniQuizCommandHandler(IMapper mapper, IMiniQuizRepository miniQuizRepository,
                                         MiniQuizBusinessRules miniQuizBusinessRules)
        {
            _mapper = mapper;
            _miniQuizRepository = miniQuizRepository;
            _miniQuizBusinessRules = miniQuizBusinessRules;
        }

        public async Task<DeletedMiniQuizResponse> Handle(DeleteMiniQuizCommand request, CancellationToken cancellationToken)
        {
            MiniQuiz? miniQuiz = await _miniQuizRepository.GetAsync(predicate: mq => mq.Id == request.Id, cancellationToken: cancellationToken);
            await _miniQuizBusinessRules.MiniQuizShouldExistWhenSelected(miniQuiz);

            await _miniQuizRepository.DeleteAsync(miniQuiz!);

            DeletedMiniQuizResponse response = _mapper.Map<DeletedMiniQuizResponse>(miniQuiz);
            return response;
        }
    }
}