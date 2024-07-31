using Core.Contracts;
using Core.Models;
using Spectre.Console;

namespace Console.Scenarios;

public class CreateAccountScenario : IScenario
{
    private readonly ICurrentAdminService _adminService;

    public CreateAccountScenario(ICurrentAdminService adminService)
    {
        adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));

        _adminService = adminService;
    }

    public string Name => "Create Account";

    public Task Run()
    {
        int id = AnsiConsole.Ask<int>("Enter account id");
        int pin = AnsiConsole.Ask<int>("Enter pin");

        _adminService.Admin?.OpenAccount(new BankAccount(id, pin, 0));
        AnsiConsole.WriteLine("Success");

        AnsiConsole.Ask<string>("Ok");

        return Task.CompletedTask;
    }
}