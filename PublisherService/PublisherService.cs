using Publisher;
using Subscribers;

namespace PublisherService;

public class PublishService : IPublishService
{
    private readonly IPublisher<int> _intPublisher; 
    private readonly IPublisher<string> _stringPublisher;
    
    public PublishService(IPublisher<int> intPublisher, IPublisher<string> stringPublisher)
    {
        _intPublisher = intPublisher; //create publisher of type integer
        _stringPublisher = stringPublisher; //create publisher of type integer 
    }

    public void CreateNumberChannelSubscriber()
    {
        Subscriber<int> intSubscriber = new Subscriber<int>(_intPublisher);
        intSubscriber.Publisher.EventPublisher += NumberChannel; //event method to listen publish data
    }

    public void CreateTextChannelSubscriber()
    {
        Subscriber<string> intSubscriber = new Subscriber<string>(_stringPublisher);
        intSubscriber.Publisher.EventPublisher += TextChannel; //event method to listen publish data
    }

    public void Publish(int value)
    {
        _intPublisher.PublishData(value); // publisher publish message
    }

    public void Publish(string value)
    {
        _stringPublisher.PublishData(value); // publisher publish message
    }

    public void NumberChannel(object sender, EventArguments<int> e)
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"Hey. I got the number: {e.Message}.");
        Console.ResetColor();
    }

    public void TextChannel(object sender, EventArguments<string> e)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;       
        Console.WriteLine("Hey I got the text: " + e.Message);
        Console.ResetColor();
    }
}