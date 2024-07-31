namespace Core.Contracts;

public interface IAccountService
{
    public Task Login(long id, int pin);
    public void Logout();
}