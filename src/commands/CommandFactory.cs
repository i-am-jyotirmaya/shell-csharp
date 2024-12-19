public static class CommandFactory
{
    public static ICommand CreateCommand(string commandName, string commandArguments)
    {
        return commandName.ToLower() switch
        {
            BuiltinCommands.ECHO => new EchoCommand(commandName, commandArguments),
            BuiltinCommands.TYPE => new TypeCommand(commandName, commandArguments),
            _ => new ExternalCommand(commandName, commandArguments)
        };
    }
}