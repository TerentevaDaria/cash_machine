using Core.Abstractions;
using Core.Models;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace DataAccess.Repositories;

public class HistoryRepository : IOperationHistoryRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public HistoryRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async IAsyncEnumerable<OperationInfo> GetByAccountId(long id)
    {
        const string sql = """
                               select account_id, change
                               from history
                               where account_id = :id;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (reader.IsOnRow)
        {
            yield return new OperationInfo(reader.GetFloat(1), reader.GetInt64(0));
        }
    }

    public async Task Add(long id, float balanceChange)
    {
        const string sql = """
                               insert into history (account_id, change)
                               values (:account_id, :change);
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("account_id", id);
        command.AddParameter("change", balanceChange);

        await command.ExecuteReaderAsync();
    }
}