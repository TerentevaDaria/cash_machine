using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create table admin
    (
        admin_id bigint primary key ,
        password text not null
    );

    create table account
    (
        account_id bigint primary key ,
        pin integer not null ,
        balance integer not null
    );

    create table history
    (
        history_id bigint primary key generated always as identity ,
        account_id bigint not null , 
        change integer not null
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table admin;
    drop table account;
    drop table history;
    """;
}