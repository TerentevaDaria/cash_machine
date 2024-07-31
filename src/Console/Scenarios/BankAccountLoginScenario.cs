using Core.Contracts;
using Core.Exceptions;
using Spectre.Console;

namespace Console.Scenarios;

public class BankAccountLoginScenario : IScenario
{
    private readonly IAccountService _accountService;

    public BankAccountLoginScenario(IAccountService accountService)
    {
        accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));

        _accountService = accountService;
    }

    public string Name => "User";

    public async Task Run()
    {
        int id = AnsiConsole.Ask<int>("Enter account id");
        int pin = AnsiConsole.Ask<int>("Enter pin");

        string message;
        try
        {
            await _accountService.Login(id, pin);
            message = "Successful login";
        }
        catch (LoginFailedException e)
        {
            message = e.Message;
        }

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}