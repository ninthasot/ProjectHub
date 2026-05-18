namespace ProjectHub.Modules.Workspaces.Infrastructure.Persistence.Configurations;

public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
{
    public void Configure(EntityTypeBuilder<Invitation> builder)
    {
        builder.ToTable(WorkspaceInfrastructureConstants.Tables.Invitations, WorkspaceInfrastructureConstants.SchemaName);

        builder.HasKey(i => i.Id);

        builder.Property(i => i.WorkspaceId)
            .IsRequired();

        builder.Property(i => i.InviterId)
            .IsRequired();

        builder.Property(i => i.InviteeEmail)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(i => i.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(i => i.SentAt)
            .IsRequired();

        builder.Property(i => i.ExpiresAt)
            .IsRequired();

        builder.Property(i => i.RespondedAt);

        builder.HasIndex(i => new { i.WorkspaceId, i.InviteeEmail })
            .IsUnique();
    }
}
