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

namespace Application.Features.BootcampComments.Commands.Update;

public class UpdateBootcampCommentCommand
    : IRequest<UpdatedBootcampCommentResponse>,
        ISecuredRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }
    public string Context { get; set; }
    public Guid UserId { get; set; }
    public int BootcampId { get; set; }

    public string[] Roles => [Admin, Write, BootcampCommentsOperationClaims.Update];

    public class UpdateBootcampCommentCommandHandler
        : IRequestHandler<UpdateBootcampCommentCommand, UpdatedBootcampCommentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampCommentRepository _bootcampCommentRepository;
        private readonly BootcampCommentBusinessRules _bootcampCommentBusinessRules;

        public UpdateBootcampCommentCommandHandler(
            IMapper mapper,
            IBootcampCommentRepository bootcampCommentRepository,
            BootcampCommentBusinessRules bootcampCommentBusinessRules
        )
        {
            _mapper = mapper;
            _bootcampCommentRepository = bootcampCommentRepository;
            _bootcampCommentBusinessRules = bootcampCommentBusinessRules;
        }

        public async Task<UpdatedBootcampCommentResponse> Handle(
            UpdateBootcampCommentCommand request,
            CancellationToken cancellationToken
        )
        {
            BootcampComment? bootcampComment = await _bootcampCommentRepository.GetAsync(
                predicate: bc => bc.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _bootcampCommentBusinessRules.BootcampCommentShouldExistWhenSelected(bootcampComment);
            bootcampComment = _mapper.Map(request, bootcampComment);

            await _bootcampCommentRepository.UpdateAsync(bootcampComment!);

            UpdatedBootcampCommentResponse response = _mapper.Map<UpdatedBootcampCommentResponse>(bootcampComment);
            return response;
        }
    }
}
