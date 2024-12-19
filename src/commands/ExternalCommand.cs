using System.Diagnostics;
using System.Text;

public class ExternalCommand(string commandName, string[] commandArguments) : ICommand
{
    public string CommandName { get; } = commandName;
    public string[] CommandArguments { get; } = commandArguments;
    public bool IsBuiltinCommand { get; } = !ExternalCommandsHelper.Instance.IsExternalCommand(commandName);

    public async Task Execute()
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = ExternalCommandsHelper.Instance.GetCommandPath(CommandName),
                Arguments = string.Join(" ",
                    CommandArguments.Select(arg => arg.Contains(' ') ? $"\"{arg}\"" : arg))
            }
        };
        process.Start();
        await process.WaitForExitAsync();
    }
}