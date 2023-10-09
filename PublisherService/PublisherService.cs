using Publisher;
using Subscribers;

namespace PublisherService;

public class PublishService : IPublishService
{
    private readonly IPublisher<int> _intPublisher; 
    private readonly IPublisher<string> _stringPublisher;
    private readonly IMessagePresenter<int> _intPresenter;
    private readonly IMessagePresenter<string> _stringPresenter;
    
    public PublishService(
        IPublisher<int> intPublisher, 
        IPublisher<string> stringPublisher,
        IMessagePresenter<int> intPresenter,
        IMessagePresenter<string> stringPresenter
    )
    {
        _intPublisher = intPublisher;
        _stringPublisher = stringPublisher;
        _intPresenter = intPresenter;
        _stringPresenter = stringPresenter;
    }

    public void CreateNumberChannelSubscriber()
    {
        Subscriber<int> subscriber = new Subscriber<int>(_intPublisher, _intPresenter);
        subscriber.Publisher.EventPublisher += subscriber.Print; //event method to listen publish data
    }

    public void CreateTextChannelSubscriber()
    {
        Subscriber<string> subscriber = new Subscriber<string>(_stringPublisher, _stringPresenter);
        subscriber.Publisher.EventPublisher += subscriber.Print; //event method to listen publish data
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
        
    }

    public void TextChannel(object sender, EventArguments<string> e)
    {
        
    }
}