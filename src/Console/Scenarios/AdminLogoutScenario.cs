using Core.Contracts;
using Spectre.Console;

namespace Console.Scenarios;

public class AdminLogoutScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLogoutScenario(IAdminService adminService)
    {
        adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));

        _adminService = adminService;
    }

    public string Name => "Logout";

    public Task Run()
    {
        _adminService.Logout();
        AnsiConsole.WriteLine("Successful logout");

        AnsiConsole.Ask<string>("Ok");

        return Task.CompletedTask;
    }
}