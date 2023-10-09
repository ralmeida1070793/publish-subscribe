using System;
using Publisher;

namespace Subscribers;

public class NumberPresenter : IMessagePresenter<int>
{
    public void Present(object sender, EventArguments<int> e)
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"Hey. I got the number: {e.Message}.");
        Console.ResetColor();
    }
}