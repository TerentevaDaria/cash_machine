using Core.Contracts;
using Core.Exceptions;

namespace Core.Services;

public class CurrentAccountService : ICurrentAccountService
{
    private readonly IBankAccountManager _accountManager;

    public CurrentAccountService(IBankAccountManager accountManager)
    {
        accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));

        _accountManager = accountManager;
    }

    public long? Id { get; set; }

    public async Task<float> GetBalance()
    {
        if (Id is null) throw new LoginRequiredException(nameof(GetBalance));

        return (await _accountManager.GetAccount(Id.Value)).Balance;
    }

    public async Task ChangeBalance(float value)
    {
        if (Id is null) throw new LoginRequiredException(nameof(ChangeBalance));

        await _accountManager.ChangeBalance(Id.Value, value);
    }
}