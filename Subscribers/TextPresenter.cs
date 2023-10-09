using System;
using Publisher;

namespace Subscribers;

public class TextPresenter : IMessagePresenter<string>
{
    public void Present(object sender, EventArguments<string> e)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;       
        Console.WriteLine("Hey I got the text: " + e.Message);
        Console.ResetColor();
    }
}