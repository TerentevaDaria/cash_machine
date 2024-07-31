using System.Diagnostics.CodeAnalysis;
using Core.Contracts;

namespace Console.Scenarios;

public class TopUpAccountScenarioProvider : IScenarioProvider
{
    private readonly ICurrentAccountService _currentAccount;

    public TopUpAccountScenarioProvider(ICurrentAccountService currentAccount)
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

        scenario = new TopUpAccountScenario(_currentAccount);
        return true;
    }
}