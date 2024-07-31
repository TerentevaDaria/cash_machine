namespace Core.Contracts;

public interface ICurrentAccountService
{
    public long? Id { get; }
    public Task<float> GetBalance();

    public Task ChangeBalance(float value);
}