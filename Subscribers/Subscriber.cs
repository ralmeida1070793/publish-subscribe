using Publisher;

namespace Subscribers;

public class Subscriber<T>
{
    public IPublisher<T> Publisher { get; private set; }
    private static IMessagePresenter<T> _presenter; 
    public Subscriber(
        IPublisher<T> publisher,
        IMessagePresenter<T> presenter
    )
    {
        Publisher = publisher;
        _presenter = presenter;
    }

    public void Print(object sender, EventArguments<T> e)
    {
        _presenter.Present(sender, e);
    }
}