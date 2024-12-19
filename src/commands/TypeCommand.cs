public class TypeCommand : BuiltinCommand
{
    public TypeCommand(string commandName, string commandArguments) : base(commandName, commandArguments)
    {
    }

    public override Task Execute()
    {
        string argCommand = CommandArguments.Split(' ')[0];

        if (CommandHelper.GetBuiltinCommands().Contains(argCommand))
        {
            Console.WriteLine($"{argCommand} is a shell builtin");
        }
        else if (ExternalCommandsHelper.Instance.IsExternalCommand(argCommand))
        {
            Console.WriteLine($"{argCommand} is {ExternalCommandsHelper.Instance.GetCommandPath(argCommand)}");
        }
        else
        {
            Console.WriteLine($"{argCommand}: not found");
        }

        return Task.CompletedTask;
    }
}
