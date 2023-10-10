namespace Publisher.Publisher;

public interface IPublisher<T>
{
    void PublishData(T message);
}