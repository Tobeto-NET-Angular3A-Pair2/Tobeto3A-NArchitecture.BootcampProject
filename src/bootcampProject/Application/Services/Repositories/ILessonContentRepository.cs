using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILessonContentRepository : IAsyncRepository<LessonContent, int>, IRepository<LessonContent, int> { }
