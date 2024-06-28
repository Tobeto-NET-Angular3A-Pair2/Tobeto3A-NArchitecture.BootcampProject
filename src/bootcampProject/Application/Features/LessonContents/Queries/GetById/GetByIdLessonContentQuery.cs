using Application.Features.Applicants.Constants;
using Application.Features.Bootcamps.Constants;
using Application.Features.Instructors.Constants;
using Application.Features.LessonContents.Constants;
using Application.Features.LessonContents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.LessonContents.Constants.LessonContentsOperationClaims;

namespace Application.Features.LessonContents.Queries.GetById;

public class GetByIdLessonContentQuery : IRequest<GetByIdLessonContentResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles =>
        new[]
        {
            LessonContentsOperationClaims.Admin,
            LessonContentsOperationClaims.Write,
            LessonContentsOperationClaims.Create,
            InstructorsOperationClaims.Admin,
            ApplicantsOperationClaims.Admin
        };

    public class GetByIdLessonContentQueryHandler : IRequestHandler<GetByIdLessonContentQuery, GetByIdLessonContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonContentRepository _lessonContentRepository;
        private readonly LessonContentBusinessRules _lessonContentBusinessRules;

        public GetByIdLessonContentQueryHandler(
            IMapper mapper,
            ILessonContentRepository lessonContentRepository,
            LessonContentBusinessRules lessonContentBusinessRules
        )
        {
            _mapper = mapper;
            _lessonContentRepository = lessonContentRepository;
            _lessonContentBusinessRules = lessonContentBusinessRules;
        }

        public async Task<GetByIdLessonContentResponse> Handle(
            GetByIdLessonContentQuery request,
            CancellationToken cancellationToken
        )
        {
            LessonContent? lessonContent = await _lessonContentRepository.GetAsync(
                predicate: lc => lc.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _lessonContentBusinessRules.LessonContentShouldExistWhenSelected(lessonContent);

            GetByIdLessonContentResponse response = _mapper.Map<GetByIdLessonContentResponse>(lessonContent);
            return response;
        }
    }
}
