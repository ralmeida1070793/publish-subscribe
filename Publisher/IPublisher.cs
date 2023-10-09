namespace Publisher;

public interface IPublisher<T>
{
    event EventHandler<EventArguments<T>> EventPublisher;
    void OnEventPublisher(EventArguments<T> args);
    void PublishData(T message);
}