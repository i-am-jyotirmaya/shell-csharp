using System.Reflection;
using System.Text.RegularExpressions;

public static class CommandHelper
{
    // This function safely parses a command string into tokens
    // It handles spaces, quotes, and escape characters
    // Example: "echo \"Hello, 'World!'\"" returns ["echo", "Hello, 'World!'"]
    public static string[] GetCommandTokens(this string command)
    {
        string[] commandSplit = command.Split(' ');
        List<string> tokens = [commandSplit[0]];
        string shellCommandArgs = commandSplit.Length > 1 ? command[(tokens[0].Length + 1)..]
            : string.Empty;
        var argsArray = Regex.IsMatch(shellCommandArgs, "^['\"]") switch
        {
            true => Regex.Matches(shellCommandArgs, $"{shellCommandArgs[0]}(.*?){shellCommandArgs[0]}")
                        .Select(m => m.Groups[1].Value)
                        .ToArray(),
            false => Regex.Split(command, "\\s+")
                         .Skip(1)
                         .Select(s => s.Replace("\\", ""))
                         .ToArray()
        };

        tokens.AddRange(argsArray);
        return [.. tokens];
    }


    public static IEnumerable<string> GetBuiltinCommands()
    {
        var commands = typeof(BuiltinCommands).GetFields(BindingFlags.Public | BindingFlags.Static)
                        .Where(field => field.FieldType == typeof(string))
                        .Select(field => field.GetRawConstantValue() as string);
        return commands!;
    }
}