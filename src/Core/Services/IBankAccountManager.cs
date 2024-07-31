using Core.Models;

namespace Core.Services;

public interface IBankAccountManager
{
    public Task<BankAccount> GetAccount(long id);

    public Task ChangeBalance(long id, float value);
}