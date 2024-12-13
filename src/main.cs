
using System.Net;
using System.Net.Sockets;
// You can use print statements as follows for debugging, they'll be visible when running tests.
// Console.WriteLine("Logs from your program will appear here!");

// Uncomment this line to pass the first stage
string command = TerminalHelper.PromptAndGetShellInput();
do
{
    Console.WriteLine($"{command}: command not found");

    command = TerminalHelper.PromptAndGetShellInput();
} while (command != "exit 0");


