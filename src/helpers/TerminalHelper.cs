public class TerminalHelper
{
    private const string SHELL_PROMPT = "$ ";
    public static string PromptAndGetShellInput()
    {
        Console.Write(SHELL_PROMPT);
        string? command = Console.ReadLine();
        if (string.IsNullOrEmpty(command))
        {
            RenderCommandNotFound(string.Empty);
        }

        return command!;
    }

    public static void RenderCommandNotFound(string command)
    {
        Console.WriteLine($"{command}: command not found");
    }
}