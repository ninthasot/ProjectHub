namespace ProjectHub.Modules.Workspaces.Domain.Entities;

public class Invitation : Entity<Guid>
{
    public Guid WorkspaceId { get; private init; }
    public Guid InviterId { get; private init; }
    public string InviteeEmail { get; private init; } = null!;
    public InvitationStatus Status { get; private set; }
    public DateTimeOffset SentAt { get; private init; }
    public DateTimeOffset ExpiresAt { get; private init; }
    public DateTimeOffset? RespondedAt { get; private set; }

    internal static Invitation Create(
        Guid workspaceId,
        Guid inviterId,
        string inviteeEmail) => new()
    {
        Id = Guid.NewGuid(),
        WorkspaceId = workspaceId,
        InviterId = inviterId,
        InviteeEmail = inviteeEmail,
        Status = InvitationStatus.Pending,
        SentAt = DateTimeOffset.UtcNow,
        ExpiresAt = DateTimeOffset.UtcNow.AddDays(7)
    };
    internal void Accept()
    {
        Status = InvitationStatus.Accepted;
        RespondedAt = DateTimeOffset.UtcNow;
    }

    internal void Decline()
    {
        Status = InvitationStatus.Declined;
        RespondedAt = DateTimeOffset.UtcNow;
    }
}
