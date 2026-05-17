namespace ProjectHub.Shared.Abstractions.Domain;

public interface IEntity<TId>
{
    TId Id { get; set; }
}
