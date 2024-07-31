using System.Diagnostics.CodeAnalysis;
using Core.Abstractions;
using Core.Contracts;

namespace Console.Scenarios;

public class GetHistoryScenarioProvider : IScenarioProvider
{
    private readonly ICurrentAccountService _currentAccount;
    private readonly IOperationHistoryRepository _repository;

    public GetHistoryScenarioProvider(ICurrentAccountService currentAccount, IOperationHistoryRepository repository)
    {
        currentAccount = currentAccount ?? throw new ArgumentNullException(nameof(currentAccount));
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        _currentAccount = currentAccount;
        _repository = repository;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.Id is null)
        {
            scenario = null;
            return false;
        }

        scenario = new GetHistoryScenario(_currentAccount, _repository);
        return true;
    }
}