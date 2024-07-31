using Core.Abstractions;
using Core.Contracts;
using Core.Exceptions;
using Core.Models;

namespace Core.Services;

public class AccountService : IAccountService
{
    private readonly IBankAccountRepository _repository;
    private readonly CurrentAccountService _currentAccount;

    public AccountService(IBankAccountRepository repository, CurrentAccountService currentAccount)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));
        currentAccount = currentAccount ?? throw new ArgumentNullException(nameof(currentAccount));

        _repository = repository;
        _currentAccount = currentAccount;
    }

    public async Task Login(long id, int pin)
    {
        BankAccount account;
        try
        {
            account = await _repository.GetById(id);
        }
        catch (RepositoryException)
        {
            throw new LoginFailedException("account " + id + " not found");
        }

        if (pin != account.Pin) throw new LoginFailedException("wrong pin");

        _currentAccount.Id = id;
    }

    public void Logout()
    {
        _currentAccount.Id = null;
    }
}