using Core.Contracts;
using Core.Exceptions;
using Spectre.Console;

namespace Console.Scenarios;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLoginScenario(IAdminService adminService)
    {
        adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));

        _adminService = adminService;
    }

    public string Name => "Admin";

    public async Task Run()
    {
        int id = AnsiConsole.Ask<int>("Enter your id");
        string password = AnsiConsole.Ask<string>("Enter password");

        string message;
        try
        {
            await _adminService.Login(id, password);
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