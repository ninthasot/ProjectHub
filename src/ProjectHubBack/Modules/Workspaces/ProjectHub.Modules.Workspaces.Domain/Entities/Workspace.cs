namespace ProjectHub.Modules.Workspaces.Domain.Entities;

public class Workspace : AggregateRoot<Guid>
{
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public Guid OwnerId { get; private set; }
    public DateTimeOffset CreatedAt { get; private init; }
    public DateTimeOffset? UpdatedAt { get; private set; }

    private readonly List<WorkspaceMember> _members = [];
    private readonly List<Invitation> _invitations = [];

    public IReadOnlyCollection<WorkspaceMember> Members => _members.AsReadOnly();
    public IReadOnlyCollection<Invitation> Invitations => _invitations.AsReadOnly();

    public static Workspace Create(
        string name,
        string? description,
        Guid ownerId) => new()
    {
        Id = Guid.NewGuid(),
        Name = name,
        Description = description,
        OwnerId = ownerId,
        CreatedAt = DateTimeOffset.UtcNow
    };

    public void UpdateDetails(
        string name,
        string? description)
    {
        Name = name;
        Description = description;
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    public void AddMember(
        Guid userId,
        WorkspaceRole role)
    {
        var member = WorkspaceMember.Create(Id, userId, role);
        _members.Add(member);
    }

    public void RemoveMember(Guid userId)
    {
        WorkspaceMember? member = _members.FirstOrDefault(m => m.UserId == userId);
        if (member is not null)
        {
            _members.Remove(member);
        }
    }
    public void ChangeMemberRole(Guid userId, WorkspaceRole role)
    {
        WorkspaceMember? member = _members.FirstOrDefault(m => m.UserId == userId);
        member?.ChangeRole(role);
    }

    public void Invite(Guid invitedByUserId, string email)
    {
        var invitation = Invitation.Create(Id, invitedByUserId, email);
        _invitations.Add(invitation);
    }

    public void AcceptInvitation(Guid invitationId)
    {
        Invitation? invitation = _invitations.FirstOrDefault(i => i.Id == invitationId);
        invitation?.Accept();
    }

    public void DeclineInvitation(Guid invitationId)
    {
        Invitation? invitation = _invitations.FirstOrDefault(i => i.Id == invitationId);
        invitation?.Decline();
    }


}
