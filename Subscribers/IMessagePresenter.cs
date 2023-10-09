using Publisher;

namespace Subscribers;

public interface IMessagePresenter<T>
{
    void Present(object sender, EventArguments<T> e);
}