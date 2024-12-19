public interface ICommand
{
    string CommandName { get; }
    string[] CommandArguments { get; }
    bool IsBuiltinCommand { get; }

    Task Execute();
}
