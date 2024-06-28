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

public class GetByLessonIdContentQuery : IRequest<GetByLessonIdContentResponse>, ISecuredRequest
{
    public int LessonId { get; set; }

    public string[] Roles =>
        new[]
        {
            LessonContentsOperationClaims.Admin,
            LessonContentsOperationClaims.Write,
            LessonContentsOperationClaims.Create,
            InstructorsOperationClaims.Admin,
            ApplicantsOperationClaims.Read
        };

    public class GetByLessonIdContentQueryHandler : IRequestHandler<GetByLessonIdContentQuery, GetByLessonIdContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonContentRepository _lessonContentRepository;
        private readonly LessonContentBusinessRules _lessonContentBusinessRules;

        public GetByLessonIdContentQueryHandler(
            IMapper mapper,
            ILessonContentRepository lessonContentRepository,
            LessonContentBusinessRules lessonContentBusinessRules
        )
        {
            _mapper = mapper;
            _lessonContentRepository = lessonContentRepository;
            _lessonContentBusinessRules = lessonContentBusinessRules;
        }

        public async Task<GetByLessonIdContentResponse> Handle(
           GetByLessonIdContentQuery request,
           CancellationToken cancellationToken
       )
        {
            LessonContent? lessonContent = await _lessonContentRepository.GetAsync(
                predicate: lc => lc.LessonId == request.LessonId,
                cancellationToken: cancellationToken
            );
            await _lessonContentBusinessRules.LessonContentShouldExistWhenSelected(lessonContent);

            GetByLessonIdContentResponse response = _mapper.Map<GetByLessonIdContentResponse>(lessonContent);
            return response;
        }
    }
}
