public class ExternalCommandsHelper
{
    private static readonly Lazy<ExternalCommandsHelper> _instance =
        new(() => new ExternalCommandsHelper());
    private readonly Dictionary<string, string> externalProgramsMap = [];
    private ExternalCommandsHelper()
    {
        string? path = Environment.GetEnvironmentVariable("PATH");
        if (path is not null && path.Contains(DirectoryHelper.Instance.CurrentDirectory))
        {
            path += $":{DirectoryHelper.Instance.CurrentDirectory}";
        }
        // Process the path string
        if (path != null)
        {
            var pathStrings = path.Split(':');
            foreach (string pathString in pathStrings)
            {
                string[] programsInDirectory = FileSystemHelper.GetProgramsInDirectory(pathString);

                foreach (string program in programsInDirectory)
                {
                    string command = program.Split('/').Last();
                    externalProgramsMap.TryAdd(command, program);
                }
            }
        }
    }

    public static ExternalCommandsHelper Instance => _instance.Value;

    public bool IsExternalCommand(string command) => externalProgramsMap.ContainsKey(command);

    public string GetCommandPath(string command) => externalProgramsMap[command];
}
