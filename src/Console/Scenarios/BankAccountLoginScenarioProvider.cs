using System.Diagnostics.CodeAnalysis;
using Core.Contracts;

namespace Console.Scenarios;

public class BankAccountLoginScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly ICurrentAccountService _currentAccount;

    public BankAccountLoginScenarioProvider(IAccountService service, ICurrentAccountService currentAdmin)
    {
        service = service ?? throw new ArgumentNullException(nameof(service));
        currentAdmin = currentAdmin ?? throw new ArgumentNullException(nameof(currentAdmin));

        _service = service;
        _currentAccount = currentAdmin;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.Id is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new BankAccountLoginScenario(_service);
        return true;
    }
}