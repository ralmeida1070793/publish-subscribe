namespace Subscriber.MessagePresenter;

public class EventArguments<T> : EventArgs
{
    public T Message { get; set; }
    public EventArguments(T message)
    {
        Message = message;
    }
}