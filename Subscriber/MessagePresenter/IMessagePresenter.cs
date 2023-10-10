namespace Subscriber.MessagePresenter;

public interface IMessagePresenter<T>
{
    void Present(object sender, EventArguments<T> e);
}