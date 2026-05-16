namespace ProjectHub.Modules.Identity.Application.Interfaces;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string hash, string password);
}