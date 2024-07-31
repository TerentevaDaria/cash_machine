using Core.Contracts;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IAdminService, AdminService>();

        collection.AddScoped<CurrentAccountService>();
        collection.AddScoped<ICurrentAccountService>(
            p => p.GetRequiredService<CurrentAccountService>());

        collection.AddScoped<CurrentAdminService>();
        collection.AddScoped<ICurrentAdminService>(
            p => p.GetRequiredService<CurrentAdminService>());

        collection.AddScoped<IBankAccountManager, BankAccountManager>();

        return collection;
    }
}