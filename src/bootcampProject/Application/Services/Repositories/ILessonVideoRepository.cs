using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILessonVideoRepository : IAsyncRepository<LessonVideo, int>, IRepository<LessonVideo, int>
{
}