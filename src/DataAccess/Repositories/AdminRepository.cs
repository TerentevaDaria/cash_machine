using Core.Abstractions;
using Core.Models;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<AdminInfo> GetById(long id)
    {
        const string sql = """
           select admin_id, password
           from admin
           where admin_id = :id;
       """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        await reader.ReadAsync();

        return new AdminInfo(reader.GetString(1), reader.GetInt64(0));
    }
}