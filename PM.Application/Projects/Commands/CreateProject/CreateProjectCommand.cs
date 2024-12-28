using ErrorOr;
using MediatR;
using PM.Application.Projects.Common;
using PM.Domain.ProjectAggregate.Entities;

namespace PM.Application.Projects.Commands.CreateProject;

public record CreateProjectCommand(
    string Code,
    string Name,
    string? Description,
    string CreatedById,
    List<string> MemberUserIds
) : IRequest<ErrorOr<ProjectResult>>;

public record BarcodeCommand(
    string Code
);