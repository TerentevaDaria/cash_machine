namespace Console;

public interface IScenario
{
    string Name { get; }

    public Task Run();
}