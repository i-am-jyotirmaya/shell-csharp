public class EchoCommand : BuiltinCommand
{
    public EchoCommand(string[] commandArguments) : base(BuiltinCommands.ECHO, commandArguments)
    {
    }

    public override Task Execute()
    {
        Console.WriteLine(string.Join(' ', CommandArguments));
        return Task.CompletedTask;
    }
}
