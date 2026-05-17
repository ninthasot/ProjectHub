namespace ProjectHub.Shared.Abstractions.Domain;

public abstract class Entity<TId> : IEntity<TId>
{
    public required TId Id { get; set; }
}
