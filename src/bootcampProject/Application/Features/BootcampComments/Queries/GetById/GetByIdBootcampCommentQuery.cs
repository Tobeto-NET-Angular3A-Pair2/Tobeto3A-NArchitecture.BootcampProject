using Application.Features.BootcampComments.Constants;
using Application.Features.BootcampComments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BootcampComments.Constants.BootcampCommentsOperationClaims;

namespace Application.Features.BootcampComments.Queries.GetById;

public class GetByIdBootcampCommentQuery : IRequest<GetByIdBootcampCommentResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBootcampCommentQueryHandler : IRequestHandler<GetByIdBootcampCommentQuery, GetByIdBootcampCommentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampCommentRepository _bootcampCommentRepository;
        private readonly BootcampCommentBusinessRules _bootcampCommentBusinessRules;

        public GetByIdBootcampCommentQueryHandler(IMapper mapper, IBootcampCommentRepository bootcampCommentRepository, BootcampCommentBusinessRules bootcampCommentBusinessRules)
        {
            _mapper = mapper;
            _bootcampCommentRepository = bootcampCommentRepository;
            _bootcampCommentBusinessRules = bootcampCommentBusinessRules;
        }

        public async Task<GetByIdBootcampCommentResponse> Handle(GetByIdBootcampCommentQuery request, CancellationToken cancellationToken)
        {
            BootcampComment? bootcampComment = await _bootcampCommentRepository.GetAsync(predicate: bc => bc.Id == request.Id, cancellationToken: cancellationToken);
            await _bootcampCommentBusinessRules.BootcampCommentShouldExistWhenSelected(bootcampComment);

            GetByIdBootcampCommentResponse response = _mapper.Map<GetByIdBootcampCommentResponse>(bootcampComment);
            return response;
        }
    }
}