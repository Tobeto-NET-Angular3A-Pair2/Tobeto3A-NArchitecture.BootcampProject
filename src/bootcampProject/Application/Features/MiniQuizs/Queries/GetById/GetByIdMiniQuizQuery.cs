using Application.Features.MiniQuizs.Constants;
using Application.Features.MiniQuizs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MiniQuizs.Constants.MiniQuizsOperationClaims;

namespace Application.Features.MiniQuizs.Queries.GetById;

public class GetByIdMiniQuizQuery : IRequest<GetByIdMiniQuizResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMiniQuizQueryHandler : IRequestHandler<GetByIdMiniQuizQuery, GetByIdMiniQuizResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMiniQuizRepository _miniQuizRepository;
        private readonly MiniQuizBusinessRules _miniQuizBusinessRules;

        public GetByIdMiniQuizQueryHandler(IMapper mapper, IMiniQuizRepository miniQuizRepository, MiniQuizBusinessRules miniQuizBusinessRules)
        {
            _mapper = mapper;
            _miniQuizRepository = miniQuizRepository;
            _miniQuizBusinessRules = miniQuizBusinessRules;
        }

        public async Task<GetByIdMiniQuizResponse> Handle(GetByIdMiniQuizQuery request, CancellationToken cancellationToken)
        {
            MiniQuiz? miniQuiz = await _miniQuizRepository.GetAsync(predicate: mq => mq.Id == request.Id, cancellationToken: cancellationToken);
            await _miniQuizBusinessRules.MiniQuizShouldExistWhenSelected(miniQuiz);

            GetByIdMiniQuizResponse response = _mapper.Map<GetByIdMiniQuizResponse>(miniQuiz);
            return response;
        }
    }
}