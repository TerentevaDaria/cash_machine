using Core.Contracts;
using Spectre.Console;

namespace Console.Scenarios;

public class BankAccountLogoutScenario : IScenario
{
    private readonly IAccountService _accountService;

    public BankAccountLogoutScenario(IAccountService accountService)
    {
        accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));

        _accountService = accountService;
    }

    public string Name => "Logout";

    public Task Run()
    {
        _accountService.Logout();
        AnsiConsole.WriteLine("Successful logout");

        AnsiConsole.Ask<string>("Ok");

        return Task.CompletedTask;
    }
}