namespace Core.Contracts;

public interface IAdminService
{
    public Task Login(long id, string password);
    public void Logout();
}