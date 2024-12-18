public static class FileSystemHelper
{
    public static string[] GetProgramsInDirectory(string directory)
    {
        if (Directory.Exists(directory))
        {
            return Directory.GetFiles(directory);
        }

        return [];

    }
}