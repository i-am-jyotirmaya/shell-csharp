public static class CommandFactory
{
    public static ICommand CreateCommand(string commandName, string commandArguments)
    {
        return commandName.ToLower() switch
        {
            BuiltinCommands.ECHO => new EchoCommand(commandArguments),
            BuiltinCommands.TYPE => new TypeCommand(commandArguments),
            BuiltinCommands.PWD => new PwdCommand(commandArguments),
            _ => new ExternalCommand(commandName, commandArguments)
        };
    }
}
