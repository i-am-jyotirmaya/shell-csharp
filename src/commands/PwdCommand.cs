
public class PwdCommand : BuiltinCommand
{
    public PwdCommand(string commandArguments) : base(BuiltinCommands.PWD, commandArguments)
    {
    }
    public override Task Execute()
    {
        Console.WriteLine(DirectoryHelper.Instance.CurrentDirectory);
        return Task.CompletedTask;
    }
}
