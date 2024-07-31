using Core.Contracts;
using Core.Exceptions;
using Spectre.Console;

namespace Console.Scenarios;

public class WithdrawFromAccountScenario : IScenario
{
    private readonly ICurrentAccountService _currentAccount;

    public WithdrawFromAccountScenario(ICurrentAccountService currentAccount)
    {
        currentAccount = currentAccount ?? throw new ArgumentNullException(nameof(currentAccount));

        _currentAccount = currentAccount;
    }

    public string Name => "withdraw";

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
            try
            {
                await _currentAccount.ChangeBalance(-value);
                message = "success withdraw";
            }
            catch (InsufficientBalanceException e)
            {
                message = e.Message;
            }
        }

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}