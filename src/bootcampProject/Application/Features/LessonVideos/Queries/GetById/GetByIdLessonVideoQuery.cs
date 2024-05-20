using Application.Features.LessonVideos.Constants;
using Application.Features.LessonVideos.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.LessonVideos.Constants.LessonVideosOperationClaims;

namespace Application.Features.LessonVideos.Queries.GetById;

public class GetByIdLessonVideoQuery : IRequest<GetByIdLessonVideoResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdLessonVideoQueryHandler : IRequestHandler<GetByIdLessonVideoQuery, GetByIdLessonVideoResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonVideoRepository _lessonVideoRepository;
        private readonly LessonVideoBusinessRules _lessonVideoBusinessRules;

        public GetByIdLessonVideoQueryHandler(IMapper mapper, ILessonVideoRepository lessonVideoRepository, LessonVideoBusinessRules lessonVideoBusinessRules)
        {
            _mapper = mapper;
            _lessonVideoRepository = lessonVideoRepository;
            _lessonVideoBusinessRules = lessonVideoBusinessRules;
        }

        public async Task<GetByIdLessonVideoResponse> Handle(GetByIdLessonVideoQuery request, CancellationToken cancellationToken)
        {
            LessonVideo? lessonVideo = await _lessonVideoRepository.GetAsync(predicate: lv => lv.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonVideoBusinessRules.LessonVideoShouldExistWhenSelected(lessonVideo);

            GetByIdLessonVideoResponse response = _mapper.Map<GetByIdLessonVideoResponse>(lessonVideo);
            return response;
        }
    }
}