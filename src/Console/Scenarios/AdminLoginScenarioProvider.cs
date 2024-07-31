using System.Diagnostics.CodeAnalysis;
using Core.Contracts;

namespace Console.Scenarios;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentAdminService _currentAdmin;

    public AdminLoginScenarioProvider(IAdminService service, ICurrentAdminService currentAdmin)
    {
        service = service ?? throw new ArgumentNullException(nameof(service));
        currentAdmin = currentAdmin ?? throw new ArgumentNullException(nameof(currentAdmin));

        _service = service;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.Admin is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_service);
        return true;
    }
}