string command = TerminalHelper.PromptAndGetShellInput();
do
{
    string[] tokens = command.GetCommandTokens();
    string shellCommand = tokens[0];
    string[] shellCommandArgs = tokens.Length > 1 ? tokens[1..] : [];

    var cmd = CommandFactory.CreateCommand(shellCommand, shellCommandArgs);

    if (cmd is ExternalCommand && !ExternalCommandsHelper.Instance.IsExternalCommand(shellCommand))
    {
        TerminalHelper.RenderCommandNotFound(shellCommand);
    }
    else
    {
        await cmd.Execute();
    }

    command = TerminalHelper.PromptAndGetShellInput();
} while (command != "exit 0");
