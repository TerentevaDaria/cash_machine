using Console.Scenarios;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, BankAccountLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, BankAccountLogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, TopUpAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawFromAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetHistoryScenarioProvider>();

        return collection;
    }
}