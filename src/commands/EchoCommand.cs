public class EchoCommand : BuiltinCommand
{
    public EchoCommand(string commandName, string commandArguments) : base(commandName, commandArguments)
    {
    }

    public override Task Execute()
    {
        Console.WriteLine(CommandArguments);
        return Task.CompletedTask;
    }
}
