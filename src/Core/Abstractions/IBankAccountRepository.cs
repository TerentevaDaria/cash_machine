using Core.Models;

namespace Core.Abstractions;

public interface IBankAccountRepository
{
    public Task Add(BankAccount account);
    public Task DeleteById(long id);
    public Task Update(BankAccount account);

    public Task<BankAccount> GetById(long id);
}