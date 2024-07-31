using Core.Abstractions;
using Core.Models;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace DataAccess.Repositories;

public class AccountRepository : IBankAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<BankAccount> GetById(long id)
    {
        const string sql = """
                               select account_id, pin, balance
                               from account
                               where account_id = :id;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        await reader.ReadAsync();

        return new BankAccount(reader.GetInt64(0), reader.GetInt32(1), reader.GetFloat(2));
    }

    public async Task Add(BankAccount account)
    {
        account = account ?? throw new ArgumentNullException(nameof(account));

        const string sql = """
                               insert into account (account_id, pin, balance)
                               values (:account_id, :pin, :balance);
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("account_id", account.Id);
        command.AddParameter("pin", account.Pin);
        command.AddParameter("balance", account.Balance);

        await command.ExecuteNonQueryAsync();
    }

    public async Task DeleteById(long id)
    {
        const string sql = """
                               delete from account
                               where account_id = :id;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);

        await command.ExecuteNonQueryAsync();
    }

    public async Task Update(BankAccount account)
    {
        account = account ?? throw new ArgumentNullException(nameof(account));

        const string sql = """
                           update account
                           set balance = :balance
                           where account_id = :account_id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("account_id", account.Id);
        command.AddParameter("balance", account.Balance);

        await command.ExecuteNonQueryAsync();
    }
}