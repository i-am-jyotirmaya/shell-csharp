
public class PwdCommand : BuiltinCommand
{
    public PwdCommand() : base(BuiltinCommands.PWD, [])
    {
    }
    public override Task Execute()
    {
        Console.WriteLine(DirectoryHelper.Instance.CurrentDirectory);
        return Task.CompletedTask;
    }
}
