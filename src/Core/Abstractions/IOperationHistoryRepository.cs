using Core.Models;

namespace Core.Abstractions;

public interface IOperationHistoryRepository
{
    public Task Add(long id, float balanceChange);
    public IAsyncEnumerable<OperationInfo> GetByAccountId(long id);
}