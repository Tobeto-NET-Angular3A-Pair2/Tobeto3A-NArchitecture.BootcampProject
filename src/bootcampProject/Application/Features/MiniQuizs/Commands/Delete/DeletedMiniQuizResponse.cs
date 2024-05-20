using NArchitecture.Core.Application.Responses;

namespace Application.Features.MiniQuizs.Commands.Delete;

public class DeletedMiniQuizResponse : IResponse
{
    public int Id { get; set; }
}