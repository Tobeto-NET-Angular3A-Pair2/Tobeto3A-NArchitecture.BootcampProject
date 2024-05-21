using Application.Features.MiniQuizs.Constants;
using Application.Features.MiniQuizs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.MiniQuizs.Constants.MiniQuizsOperationClaims;

namespace Application.Features.MiniQuizs.Commands.Create;

public class CreateMiniQuizCommand
    : IRequest<CreatedMiniQuizResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public int LessonId { get; set; }

    public string[] Roles => [Admin, Write, MiniQuizsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMiniQuizs"];

    public class CreateMiniQuizCommandHandler : IRequestHandler<CreateMiniQuizCommand, CreatedMiniQuizResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMiniQuizRepository _miniQuizRepository;
        private readonly MiniQuizBusinessRules _miniQuizBusinessRules;

        public CreateMiniQuizCommandHandler(
            IMapper mapper,
            IMiniQuizRepository miniQuizRepository,
            MiniQuizBusinessRules miniQuizBusinessRules
        )
        {
            _mapper = mapper;
            _miniQuizRepository = miniQuizRepository;
            _miniQuizBusinessRules = miniQuizBusinessRules;
        }

        public async Task<CreatedMiniQuizResponse> Handle(CreateMiniQuizCommand request, CancellationToken cancellationToken)
        {
            MiniQuiz miniQuiz = _mapper.Map<MiniQuiz>(request);

            await _miniQuizRepository.AddAsync(miniQuiz);

            CreatedMiniQuizResponse response = _mapper.Map<CreatedMiniQuizResponse>(miniQuiz);
            return response;
        }
    }
}
