public class DirectoryNotFoundException : Exception
{
    public DirectoryNotFoundException() : base("Directory does not exist") { }
}
