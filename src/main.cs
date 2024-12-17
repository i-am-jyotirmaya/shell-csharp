string command = TerminalHelper.PromptAndGetShellInput();
do
{
    string[] tokens = command.GetCommandTokens();
    string shellCommand = tokens[0];
    string[] shellCommandArgs = tokens.Length > 1 ? tokens[1..] : [];

    switch (shellCommand)
    {
        case Commands.ECHO:
            Console.WriteLine(string.Join(" ", shellCommandArgs));
            break;
        default:
            Console.WriteLine($"{shellCommand}: command not found");
            break;
    }


    command = TerminalHelper.PromptAndGetShellInput();
} while (command != "exit 0");


