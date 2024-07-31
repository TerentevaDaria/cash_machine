using System.Globalization;
using Core.Contracts;
using Spectre.Console;

namespace Console.Scenarios;

public class GetBalanceScenario : IScenario
{
    private readonly ICurrentAccountService _currentAccount;

    public GetBalanceScenario(ICurrentAccountService currentAccount)
    {
        currentAccount = currentAccount ?? throw new ArgumentNullException(nameof(currentAccount));

        _currentAccount = currentAccount;
    }

    public string Name => "Get balance";

    public async Task Run()
    {
        float balance = await _currentAccount.GetBalance();

        AnsiConsole.WriteLine(balance.ToString(CultureInfo.InvariantCulture));
        AnsiConsole.Ask<string>("Ok");
    }
}