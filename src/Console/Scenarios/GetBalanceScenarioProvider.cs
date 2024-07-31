using System.Diagnostics.CodeAnalysis;
using Core.Contracts;

namespace Console.Scenarios;

public class GetBalanceScenarioProvider : IScenarioProvider
{
    private readonly ICurrentAccountService _currentAccount;

    public GetBalanceScenarioProvider(ICurrentAccountService currentAccount)
    {
        currentAccount = currentAccount ?? throw new ArgumentNullException(nameof(currentAccount));

        _currentAccount = currentAccount;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.Id is null)
        {
            scenario = null;
            return false;
        }

        scenario = new GetBalanceScenario(_currentAccount);
        return true;
    }
}