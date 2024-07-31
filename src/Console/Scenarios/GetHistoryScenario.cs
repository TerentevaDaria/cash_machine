using System.Globalization;
using Core.Abstractions;
using Core.Contracts;
using Core.Models;
using Spectre.Console;

namespace Console.Scenarios;

public class GetHistoryScenario : IScenario
{
    private readonly ICurrentAccountService _currentAccount;
    private readonly IOperationHistoryRepository _repository;

    public GetHistoryScenario(ICurrentAccountService currentAccount, IOperationHistoryRepository repository)
    {
        currentAccount = currentAccount ?? throw new ArgumentNullException(nameof(currentAccount));
        repository = repository ?? throw new ArgumentNullException(nameof(repository));

        _currentAccount = currentAccount;
        _repository = repository;
    }

    public string Name => "Get history";

    public async Task Run()
    {
        if (_currentAccount.Id is null)
        {
            AnsiConsole.WriteLine("Login required");
        }
        else
        {
            IAsyncEnumerable<OperationInfo> history = _repository.GetByAccountId(_currentAccount.Id.Value);

            await foreach (OperationInfo operationInfo in history)
            {
                AnsiConsole.WriteLine(operationInfo.AccountId.ToString(CultureInfo.InvariantCulture) + ' ' +
                                      operationInfo.Change);
            }
        }

        AnsiConsole.Ask<string>("Ok");
    }
}