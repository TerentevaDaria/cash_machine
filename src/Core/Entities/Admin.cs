using Core.Abstractions;
using Core.Exceptions;
using Core.Models;

namespace Core.Entities;

public class Admin
{
    private readonly IBankAccountRepository _repository;

    public Admin(IBankAccountRepository repository, long id, string password)
    {
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        _repository = repository;
        Id = id;
        Password = password;
    }

    public long Id { get; }
    internal string Password { get; }

    public async Task OpenAccount(BankAccount account)
    {
        account = account ?? throw new ArgumentNullException(nameof(account));

        try
        {
            await _repository.Add(account);
        }
        catch (Exception e)
        {
            throw new RepositoryException(e.Message, e);
        }
    }
}