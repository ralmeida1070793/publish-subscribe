using Subscriber.MessagePresenter;

namespace Subscriber;

public class EventDispatcher<T>
{
    public event EventHandler<EventArguments<T>> EventPublisher = delegate { };

    public void OnEventDispatch(EventArguments<T> args)
    {
        EventPublisher(this, args);
    }

    public void Dispatch(T data)
    {
        var message = (EventArguments<T>)Activator.CreateInstance(typeof(EventArguments<T>), new object[] { data });
        OnEventDispatch(message);
    }
}