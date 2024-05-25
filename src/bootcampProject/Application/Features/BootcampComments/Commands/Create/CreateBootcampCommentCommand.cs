using Application.Features.BootcampComments.Constants;
using Application.Features.BootcampComments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.BootcampComments.Constants.BootcampCommentsOperationClaims;

namespace Application.Features.BootcampComments.Commands.Create;

public class CreateBootcampCommentCommand
    : IRequest<CreatedBootcampCommentResponse>,
        ISecuredRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public string Context { get; set; }
    public Guid UserId { get; set; }
    public int BootcampId { get; set; }

    public string[] Roles => [Admin, Write, BootcampCommentsOperationClaims.Create];

    public class CreateBootcampCommentCommandHandler
        : IRequestHandler<CreateBootcampCommentCommand, CreatedBootcampCommentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampCommentRepository _bootcampCommentRepository;
        private readonly BootcampCommentBusinessRules _bootcampCommentBusinessRules;

        public CreateBootcampCommentCommandHandler(
            IMapper mapper,
            IBootcampCommentRepository bootcampCommentRepository,
            BootcampCommentBusinessRules bootcampCommentBusinessRules
        )
        {
            _mapper = mapper;
            _bootcampCommentRepository = bootcampCommentRepository;
            _bootcampCommentBusinessRules = bootcampCommentBusinessRules;
        }

        public async Task<CreatedBootcampCommentResponse> Handle(
            CreateBootcampCommentCommand request,
            CancellationToken cancellationToken
        )
        {
            BootcampComment bootcampComment = _mapper.Map<BootcampComment>(request);

            await _bootcampCommentRepository.AddAsync(bootcampComment);

            CreatedBootcampCommentResponse response = _mapper.Map<CreatedBootcampCommentResponse>(bootcampComment);
            return response;
        }
    }
}
