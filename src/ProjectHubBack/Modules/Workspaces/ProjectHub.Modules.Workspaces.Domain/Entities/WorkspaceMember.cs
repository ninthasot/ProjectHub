namespace ProjectHub.Modules.Workspaces.Domain.Entities;

public class WorkspaceMember : Entity<Guid>
{
    public Guid WorkspaceId { get; private init; }
    public Guid UserId { get; private init; }
    public WorkspaceRole Role { get; private set; }
    public DateTimeOffset JoinedAt { get; private init; }

    internal static WorkspaceMember Create(
        Guid workspaceId,
        Guid userId,
        WorkspaceRole role) => new()
    {
        Id = Guid.NewGuid(),
        WorkspaceId = workspaceId,
        UserId = userId,
        Role = role,
        JoinedAt = DateTimeOffset.UtcNow
    };

    internal void ChangeRole(WorkspaceRole role) => Role = role;
}
