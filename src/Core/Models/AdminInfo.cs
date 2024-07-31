namespace Core.Models;

public class AdminInfo
{
    public AdminInfo(string password, long id)
    {
        Password = password;
        Id = id;
    }

    public long Id { get; }
    public string Password { get; }
}