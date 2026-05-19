namespace ProjectHub.Modules.Workspaces.Infrastructure.Persistence.Configurations;

public class WorkspaceMemberConfiguration : IEntityTypeConfiguration<WorkspaceMember>
{
    public void Configure(EntityTypeBuilder<WorkspaceMember> builder)
    {
        builder.ToTable(WorkspaceInfrastructureConstants.Tables.WorkspaceMembers, WorkspaceInfrastructureConstants.SchemaName);

        builder.HasKey(m => m.Id);

        builder.Property(m => m.WorkspaceId)
            .IsRequired();

        builder.Property(m => m.UserId)
            .IsRequired();

        builder.Property(m => m.Role)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(m => m.JoinedAt)
            .IsRequired();
    }
}
