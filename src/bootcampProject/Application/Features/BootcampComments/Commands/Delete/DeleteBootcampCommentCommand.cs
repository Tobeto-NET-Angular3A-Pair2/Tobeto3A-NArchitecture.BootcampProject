using Application.Features.BootcampComments.Constants;
using Application.Features.BootcampComments.Constants;
using Application.Features.BootcampComments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BootcampComments.Constants.BootcampCommentsOperationClaims;

namespace Application.Features.BootcampComments.Commands.Delete;

public class DeleteBootcampCommentCommand : IRequest<DeletedBootcampCommentResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, BootcampCommentsOperationClaims.Delete];

    public class DeleteBootcampCommentCommandHandler : IRequestHandler<DeleteBootcampCommentCommand, DeletedBootcampCommentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampCommentRepository _bootcampCommentRepository;
        private readonly BootcampCommentBusinessRules _bootcampCommentBusinessRules;

        public DeleteBootcampCommentCommandHandler(IMapper mapper, IBootcampCommentRepository bootcampCommentRepository,
                                         BootcampCommentBusinessRules bootcampCommentBusinessRules)
        {
            _mapper = mapper;
            _bootcampCommentRepository = bootcampCommentRepository;
            _bootcampCommentBusinessRules = bootcampCommentBusinessRules;
        }

        public async Task<DeletedBootcampCommentResponse> Handle(DeleteBootcampCommentCommand request, CancellationToken cancellationToken)
        {
            BootcampComment? bootcampComment = await _bootcampCommentRepository.GetAsync(predicate: bc => bc.Id == request.Id, cancellationToken: cancellationToken);
            await _bootcampCommentBusinessRules.BootcampCommentShouldExistWhenSelected(bootcampComment);

            await _bootcampCommentRepository.DeleteAsync(bootcampComment!);

            DeletedBootcampCommentResponse response = _mapper.Map<DeletedBootcampCommentResponse>(bootcampComment);
            return response;
        }
    }
}