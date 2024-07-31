using Core.Contracts;
using Spectre.Console;

namespace Console.Scenarios;

public class TopUpAccountScenario : IScenario
{
    private readonly ICurrentAccountService _currentAccount;

    public TopUpAccountScenario(ICurrentAccountService currentAccount)
    {
        currentAccount = currentAccount ?? throw new ArgumentNullException(nameof(currentAccount));

        _currentAccount = currentAccount;
    }

    public string Name => "top up";

    public async Task Run()
    {
        int value = AnsiConsole.Ask<int>("Enter value");

        string message;
        if (value <= 0)
        {
            message = nameof(value) + " should be positive";
        }
        else
        {
            await _currentAccount.ChangeBalance(value);
            message = "success top up";
        }

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}