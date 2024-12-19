public class DirectoryHelper
{
    private static DirectoryHelper? internalInstance;
    private DirectoryHelper() { }

    public static DirectoryHelper Instance
    {
        get
        {
            internalInstance ??= new DirectoryHelper();
            return internalInstance;
        }
    }
    public string CurrentDirectory { get; private set; } = Directory.GetCurrentDirectory();

    public void ChangeDirectory(string newDirectory)
    {
        string[] directorySegment = newDirectory.Split('/');
        string tempDirectory = directorySegment[0] == "" ? "/" : CurrentDirectory;
        for (int i = 1; i < directorySegment.Length; i++)
        {
            tempDirectory = Path.Combine(tempDirectory, directorySegment[i]);
            if (!Directory.Exists(tempDirectory))
            {
                throw new DirectoryNotFoundException();
            }
        }

        CurrentDirectory = tempDirectory;
    }

}
