using System.Diagnostics;

public class ExternalCommand(string commandName, string commandArguments) : ICommand
{
    public string CommandName { get; } = commandName;
    public string CommandArguments { get; } = commandArguments;
    public bool IsBuiltinCommand { get; } = !ExternalCommandsHelper.Instance.IsExternalCommand(commandName);

    public async Task Execute()
    {
        var process = new Process();
        process.StartInfo.FileName = ExternalCommandsHelper.Instance.GetCommandPath(CommandName);
        process.StartInfo.Arguments = CommandArguments;
        process.Start();
        await process.WaitForExitAsync();
    }
}