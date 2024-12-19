
public class CdCommand : BuiltinCommand
{
    public CdCommand(string commandArguments) : base(BuiltinCommands.CD, commandArguments)
    {
    }
    public override Task Execute()
    {
        try
        {
            DirectoryHelper.Instance.ChangeDirectory(CommandArguments);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"cd: {CommandArguments}: No such file or directory");
        }
        return Task.CompletedTask;
    }
}
