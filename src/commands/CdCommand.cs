
public class CdCommand : BuiltinCommand
{
    public CdCommand(string commandArguments) : base(BuiltinCommands.CD, commandArguments)
    {
    }
    public override Task Execute()
    {
        DirectoryHelper.Instance.ChangeDirectory(CommandArguments);
        return Task.CompletedTask;
    }
}
