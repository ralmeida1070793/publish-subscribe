using Subscriber.MessagePresenter;

namespace Subscriber;

public class Subscriber<T>
{
    private static IMessagePresenter<T> _presenter;
    public EventDispatcher<T> Dispatcher { get; private set; }
    public event EventHandler<EventArguments<T>> EventDispatcher = delegate { };
    public Subscriber(
        EventDispatcher<T> dispatcher,
        IMessagePresenter<T> presenter
    )
    {
        Dispatcher = dispatcher;
        _presenter = presenter;
    }

    public void Print(object sender, EventArguments<T> e)
    {
        _presenter.Present(sender, e);
    }  
}