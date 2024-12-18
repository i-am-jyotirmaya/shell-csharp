string command = TerminalHelper.PromptAndGetShellInput();
do
{
    string[] tokens = command.GetCommandTokens();
    string shellCommand = tokens[0];
    string[] shellCommandArgs = tokens.Length > 1 ? tokens[1..] : [];

    switch (shellCommand)
    {
        case BuiltinCommands.ECHO:
            Console.WriteLine(string.Join(" ", shellCommandArgs));
            break;
        case BuiltinCommands.TYPE:
            string argCommand = shellCommandArgs.First();
            IEnumerable<string> type = CommandHelper.GetBuiltinCommands();
            if (type.Contains(argCommand))
            {
                Console.WriteLine($"{argCommand} is a shell builtin");
                break;
            }

            Console.WriteLine($"{argCommand}: not found");
            break;
        default:
            Console.WriteLine($"{shellCommand}: command not found");
            break;
    }


    command = TerminalHelper.PromptAndGetShellInput();
} while (command != "exit 0");


