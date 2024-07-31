using Core.Abstractions;
using Core.Exceptions;
using Core.Models;

namespace Core.Services;

public class BankAccountManager : IBankAccountManager
{
    private readonly IBankAccountRepository _repository;

    public BankAccountManager(IBankAccountRepository repository)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        _repository = repository;
    }

    public async Task ChangeBalance(long id, float value)
    {
        BankAccount account = await GetAccount(id);

        if (account.Balance + value < 0) throw new InsufficientBalanceException("balance can't be negative");
        account.Balance += value;

        await _repository.Update(account);
    }

    public async Task<BankAccount> GetAccount(long id)
    {
        try
        {
            return await _repository.GetById(id);
        }
        catch (Exception e)
        {
            throw new RepositoryException(e.Message, e);
        }
    }
}