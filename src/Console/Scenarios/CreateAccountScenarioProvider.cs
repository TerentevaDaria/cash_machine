using System.Diagnostics.CodeAnalysis;
using Core.Contracts;

namespace Console.Scenarios;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly ICurrentAdminService _currentAdmin;

    public CreateAccountScenarioProvider(ICurrentAdminService currentAdmin)
    {
        currentAdmin = currentAdmin ?? throw new ArgumentNullException(nameof(currentAdmin));

        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.Admin is null)
        {
            scenario = null;
            return false;
        }

        scenario = new CreateAccountScenario(_currentAdmin);
        return true;
    }
}