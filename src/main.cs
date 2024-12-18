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
            // string? path = "/tmp/blueberry/grape/mango:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin";
            string? path = Environment.GetEnvironmentVariable("PATH");
            List<string> programsInPath = [];
            int programFromPathIndex = -1;
            // Process the path string
            if (path != null)
            {
                var pathStrings = path.Split(':');
                foreach (string pathString in pathStrings)
                {
                    programsInPath.AddRange(FileSystemHelper.GetProgramsInDirectory(pathString));
                }

                programFromPathIndex = programsInPath.FindIndex(p => argCommand.Equals(p.Split('/').Last()));
            }



            IEnumerable<string> builtinTypes = CommandHelper.GetBuiltinCommands();
            if (builtinTypes.Contains(argCommand))
            {
                Console.WriteLine($"{argCommand} is a shell builtin");
            }
            else if (programFromPathIndex >= 0)
            {
                Console.WriteLine($"{argCommand} is {programsInPath[programFromPathIndex]}");
            }
            else
            {
                Console.WriteLine($"{argCommand}: not found");
            }
            break;
        default:
            Console.WriteLine($"{shellCommand}: command not found");
            break;
    }


    command = TerminalHelper.PromptAndGetShellInput();
} while (command != "exit 0");


