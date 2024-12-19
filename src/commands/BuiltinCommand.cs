public abstract class BuiltinCommand(string commandName, string commandArguments) : ICommand
{
    public string CommandName { get; } = commandName;
    public string CommandArguments { get; } = commandArguments;
    public bool IsBuiltinCommand { get; } = CommandHelper.GetBuiltinCommands().Contains(commandName.ToLowerInvariant());

    public abstract Task Execute();
}