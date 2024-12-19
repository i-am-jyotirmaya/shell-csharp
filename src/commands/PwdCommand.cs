
public class PwdCommand : BuiltinCommand
{
    public PwdCommand(string commandArguments) : base(BuiltinCommands.PWD, commandArguments)
    {
    }
    public override Task Execute()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        Console.WriteLine(currentDirectory);
        return Task.CompletedTask;
    }
}
