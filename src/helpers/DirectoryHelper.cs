public class DirectoryHelper
{
    private static readonly Lazy<DirectoryHelper> _instance = new(() => new DirectoryHelper());
    private DirectoryHelper()
    {
        CurrentDirectory = Directory.GetCurrentDirectory();
    }

    public static DirectoryHelper Instance => _instance.Value;

    public string CurrentDirectory { get; private set; }

    public void ChangeDirectory(string newDirectory)
    {
        if (newDirectory.StartsWith("~/") || newDirectory == "~")
        {
            newDirectory = newDirectory.Replace("~", Environment.GetEnvironmentVariable("HOME")!.TrimEnd('/'));
        }

        string targetDirectory = Path.GetFullPath(newDirectory, CurrentDirectory).TrimEnd('/');

        if (!Directory.Exists(targetDirectory))
        {
            throw new DirectoryNotFoundException();
        }

        CurrentDirectory = targetDirectory;
    }
}
