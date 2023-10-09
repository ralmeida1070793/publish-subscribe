namespace Publisher;

public class Publisher<T> : IPublisher<T>
{
    public event EventHandler<EventArguments<T>> EventPublisher = delegate { };
    private readonly MessageTransform<T> _transformerStrategy;

    public Publisher(MessageTransform<T> transformerStrategy)
    {
        _transformerStrategy = transformerStrategy;
    }

    public void OnEventPublisher(EventArguments<T> args)
    {
        EventPublisher(this, args);
    }

    public void PublishData(T data)
    {
        var message = (EventArguments<T>)Activator.CreateInstance(typeof(EventArguments<T>), new object[] { _transformerStrategy.Transform(data) });
        OnEventPublisher(message);
    }
}