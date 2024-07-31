using Core.Abstractions;
using Core.Models;

namespace Core.Services;

public class HistoryWriteManager : IBankAccountManager
{
    private readonly IBankAccountManager _manager;
    private readonly IOperationHistoryRepository _repository;

    public HistoryWriteManager(IBankAccountManager manager, IOperationHistoryRepository repository)
    {
        manager = manager ?? throw new ArgumentNullException(nameof(manager));
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        _manager = manager;
        _repository = repository;
    }

    public async Task<BankAccount> GetAccount(long id)
    {
        return await _manager.GetAccount(id);
    }

    public async Task ChangeBalance(long id, float value)
    {
        await _manager.ChangeBalance(id, value);
        await _repository.Add(id, value);
    }
}