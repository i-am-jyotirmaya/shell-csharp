
public class CdCommand : BuiltinCommand
{
    public CdCommand(string[] commandArguments) : base(BuiltinCommands.CD, commandArguments)
    {
    }
    public override Task Execute()
    {
        try
        {
            DirectoryHelper.Instance.ChangeDirectory(CommandArguments[0]);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"cd: {CommandArguments[0]}: No such file or directory");
        }
        return Task.CompletedTask;
    }
}
