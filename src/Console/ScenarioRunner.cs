using Spectre.Console;

namespace Console;

public class ScenarioRunner
{
    private readonly IEnumerable<IScenarioProvider> _providers;

    public ScenarioRunner(IEnumerable<IScenarioProvider> providers)
    {
        providers = providers ?? throw new ArgumentNullException(nameof(providers));

        _providers = providers;
    }

    public async Task Run()
    {
        IEnumerable<IScenario> scenarios = GetCurrentScenarios();

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        await scenario.Run();
    }

    private IEnumerable<IScenario> GetCurrentScenarios()
    {
        foreach (IScenarioProvider provider in _providers)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
                yield return scenario;
        }
    }
}