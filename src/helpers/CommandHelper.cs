using System.Reflection;
using System.Text.RegularExpressions;

public static class CommandHelper
{
    public static string[] GetCommandTokens(this string command)
    {
        var regex = new Regex(@"[^\s""]+|""([^""]*)""");
        var matches = regex.Matches(command);

        List<string> tokens = [];

        foreach (Match match in matches)
        {
            string token = match.Groups[1].Success ? match.Groups[1].Value : match.Value;
            tokens.Add(token);
        }

        return tokens.ToArray();
    }

    public static IEnumerable<string> GetBuiltinCommands()
    {
        var commands = typeof(BuiltinCommands).GetFields(BindingFlags.Public | BindingFlags.Static)
                        .Where(field => field.FieldType == typeof(string))
                        .Select(field => field.GetRawConstantValue() as string);
        return commands!;
    }
}