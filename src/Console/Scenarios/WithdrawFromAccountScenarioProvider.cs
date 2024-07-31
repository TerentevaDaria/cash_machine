using System.Diagnostics.CodeAnalysis;
using Core.Contracts;

namespace Console.Scenarios;

public class WithdrawFromAccountScenarioProvider : IScenarioProvider
{
    private readonly ICurrentAccountService _currentAccount;

    public WithdrawFromAccountScenarioProvider(ICurrentAccountService currentAccount)
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

        scenario = new WithdrawFromAccountScenario(_currentAccount);
        return true;
    }
}