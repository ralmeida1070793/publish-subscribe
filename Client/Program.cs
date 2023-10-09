using System;
using Ninject;
using PublisherService;

public class Program
{
    private static IPublishService _publishLogic;
    
    static void Main(string[] args)
    {
        InitialiaseIoC();
        
        Console.WriteLine("Greetings");
        
        RegisterChannels();
        ReadData();
        
        Console.WriteLine("Farewell.");
    }

    private static void ReadData()
    {
        Console.WriteLine("Enter data (int or string). In order to quit, type `exit`.");
        string command;
        while ((command = Console.ReadLine()) != "exit")
        {
            Console.ResetColor();
            int intValue;
            
            if (int.TryParse(command, out intValue))
            {
                _publishLogic.Publish(intValue);
            }
            else
            {
                _publishLogic.Publish(command);
            }

            Console.WriteLine("Enter data (int or string). In order to quit, type `exit`.");
        }
    }
    
    private static void RegisterChannels()
    {
        Console.WriteLine("How many subscribers do you want to register for Numerical inputs?");
        string intSubscribers = Console.ReadLine();

        int numberChannelValue;
        if (int.TryParse(intSubscribers, out numberChannelValue))
        {
            for (int i = 0; i < numberChannelValue; i++)
            {
                _publishLogic.CreateNumberChannelSubscriber();
            }

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{numberChannelValue} subscriber has been added to Number channel!");
            Console.ResetColor();
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Error: Please enter a number");
            Console.ResetColor();
        }
        
        Console.WriteLine("How many subscribers do you want to register for Alphanumerical inputs?");
        string stringSubscribers = Console.ReadLine();

        int textChannelValue;
        if (int.TryParse(stringSubscribers, out textChannelValue))
        {
            for (int i = 0; i < textChannelValue; i++)
            {
                _publishLogic.CreateTextChannelSubscriber();
            }

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{textChannelValue} subscriber has been added to Text channel!");
            Console.ResetColor();
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Error: Please enter a number");
            Console.ResetColor();
        }
    }
    private static void InitialiaseIoC()
    {
        var kernel = new StandardKernel();
        kernel.Load(AppDomain.CurrentDomain.GetAssemblies());
        _publishLogic = kernel.Get<IPublishService>();
    }
}