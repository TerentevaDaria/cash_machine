using System.Diagnostics.CodeAnalysis;
using Core.Contracts;

namespace Console.Scenarios;

public class BankAccountLogoutScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly ICurrentAccountService _currentAccount;

    public BankAccountLogoutScenarioProvider(IAccountService service, ICurrentAccountService currentAccount)
    {
        service = service ?? throw new ArgumentNullException(nameof(service));
        currentAccount = currentAccount ?? throw new ArgumentNullException(nameof(currentAccount));

        _service = service;
        _currentAccount = currentAccount;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.Id is null)
        {
            scenario = null;
            return false;
        }

        scenario = new BankAccountLogoutScenario(_service);
        return true;
    }
}